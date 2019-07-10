using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspnetRun.Infrastructure.Data
{
    class AspnetRunCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecificationAssociation>()
                .HasKey(psa => new { psa.ProductId, psa.SpecificationId });

            modelBuilder.Entity<ProductSpecificationAssociation>()
                .HasOne(psa => psa.Product)
                .WithMany(p => p.Specifications)
                .HasForeignKey(psa => psa.ProductId);


            modelBuilder.Entity<OrderPaymentAssociation>()
                .HasKey(psa => new { psa.OrderId, psa.PaymentId });

            modelBuilder.Entity<OrderPaymentAssociation>()
                .HasOne(opa => opa.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(opa => opa.OrderId);


            modelBuilder.Entity<ContractPaymentAssociation>()
                .HasKey(psa => new { psa.ContractId, psa.PaymentId });

            modelBuilder.Entity<ContractPaymentAssociation>()
                .HasOne(cpa => cpa.Contract)
                .WithMany(c => c.Payments)
                .HasForeignKey(cpa => cpa.ContractId);
        }
    }
}
