using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspnetRun.Infrastructure.Data
{
    class AspnetRunCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecification>()
                .HasKey(psa => new { psa.ProductId, psa.SpecificationId });

            modelBuilder.Entity<ProductSpecification>()
                .HasOne(psa => psa.Product)
                .WithMany(p => p.Specifications)
                .HasForeignKey(psa => psa.ProductId);
        }
    }
}
