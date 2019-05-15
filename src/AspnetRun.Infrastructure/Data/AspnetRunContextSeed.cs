using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        private readonly AspnetRunContext _aspnetRunContext;
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public AspnetRunContextSeed(
            AspnetRunContext aspnetRunContext,
            IProductRepository productRepository,
            IRepository<Category> categoryRepository)
        {
            _aspnetRunContext = aspnetRunContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _aspnetRunContext.Database.Migrate();
            // _aspnetRunContext.Database.EnsureCreated();

            await SeedCategoriesAsync();
            await SeedProductsAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (!_categoryRepository.Table.Any())
            {
                var categories = new List<Category>
                {
                    new Category{Name="TV", Description = "TV"},
                    new Category{Name="Phone", Description = "Phone"}
                };

                await _categoryRepository.AddRangeAsync(categories);
            }
        }

        private async Task SeedProductsAsync()
        {
            if (!_productRepository.Table.Any())
            {
                var categoryTV = _categoryRepository.Table.First(c => c.Name == "TV");
                var categoryPhone = _categoryRepository.Table.First(c => c.Name == "Phone");

                var products = new List<Product>
                {
                    new Product{ Name = "IPhone X", Description = "IPhone X", UnitPrice = 19.5M, Category = categoryPhone },
                    new Product{ Name = "Samsung S10", Description = "Samsung S10", UnitPrice = 33.5M, Category = categoryPhone },
                    new Product{ Name = "LG TV", Description = "LG TV", UnitPrice = 33.5M, Category = categoryTV }
                };

                await _productRepository.AddRangeAsync(products);
            }
        }
    }
}
