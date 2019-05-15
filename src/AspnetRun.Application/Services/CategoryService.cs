using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories.Base;

namespace AspnetRun.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IAppLogger<CategoryService> _logger;

        public CategoryService(IRepository<Category> categoryRepository, IAppLogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var categoryList = await _categoryRepository.ListAllAsync();

            var categoryModels = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(categoryList);

            return categoryModels;
        }
    }
}
