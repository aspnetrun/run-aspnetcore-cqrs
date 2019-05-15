using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AspnetRunContext context)
            : base(context)
        {
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            //TODO: should be refactored
            var products = await GetAsync(p => p.Id == id, null, new List<Expression<Func<Product, object>>> { p => p.Category });
            return products.FirstOrDefault();
        }
    }
}
