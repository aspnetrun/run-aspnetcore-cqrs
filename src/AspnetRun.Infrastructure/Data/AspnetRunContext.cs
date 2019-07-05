using AspnetRun.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions<AspnetRunContext> options)
            : base(options)
        {
        }

        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction => _currentTransaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeToRegisters = typeof(Entity).GetTypeInfo().Assembly.DefinedTypes.Select(t => t.AsType());

            modelBuilder.RegisterEntities(typeToRegisters);

            modelBuilder.RegisterConvention();

            base.OnModelCreating(modelBuilder);

            modelBuilder.RegisterCustomMappings(typeToRegisters);
        }

        public async Task BeginTransactionAsync()
        {
            _currentTransaction = _currentTransaction ?? await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }

    static class AspnetRunContextConfigurations
    {
        internal static void RegisterEntities(this ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            var entityTypes = typeToRegisters.Where(t => (t.GetTypeInfo().IsSubclassOf(typeof(Entity)) || t.GetTypeInfo().IsSubclassOf(typeof(Enumeration))) && !t.GetTypeInfo().IsAbstract);

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }

        internal static void RegisterConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType.Namespace != null)
                {
                    var tableName = entity.ClrType.Name;
                    var typeBuilder = modelBuilder.Entity(entity.Name);
                    typeBuilder.ToTable(tableName);

                    if (entity.ClrType.IsSubclassOf(typeof(Entity)))
                    {
                    }
                    else if (entity.ClrType.IsSubclassOf(typeof(Enumeration)))
                    {
                        typeBuilder.Property("Id").ValueGeneratedNever();
                    }
                }
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        internal static void RegisterCustomMappings(this ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            var customModelBuilderTypes = typeToRegisters.Where(x => typeof(ICustomModelBuilder).IsAssignableFrom(x));
            foreach (var builderType in customModelBuilderTypes)
            {
                if (builderType != null && builderType != typeof(ICustomModelBuilder))
                {
                    var builder = (ICustomModelBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }
    }
}
