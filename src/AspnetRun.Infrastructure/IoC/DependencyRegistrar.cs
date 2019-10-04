using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Infrastructure.Behaviors;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Logging;
using AspnetRun.Infrastructure.Misc;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Infrastructure.Repository.Base;
using Autofac;
using MediatR;
using System.Reflection;

namespace AspnetRun.Infrastructure.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // repositories
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(EnumRepository<>)).As(typeof(IEnumRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepositoryBase<,>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(LoggerAdapter<>)).As(typeof(IAppLogger<>)).InstancePerDependency();

            builder.RegisterType<AspnetRunContextSeed>();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            //var handlerAssemblies = typeFinder.FindClassesOfType(typeof(IRequestHandler<,>))
            //    .Select(t => t.Assembly).Distinct().ToArray();
            //builder.RegisterAssemblyTypes(handlerAssemblies)
            //    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

            //// Register the Command's Validators (Validators based on FluentValidation library)
            //var validatorAssemblies = typeFinder.FindClassesOfType(typeof(IValidator<,>))
            //    .Select(t => t.Assembly).Distinct().ToArray();
            //builder.RegisterAssemblyTypes(validatorAssemblies).
            //    Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();
        }

        public int Order => 1;
    }
}
