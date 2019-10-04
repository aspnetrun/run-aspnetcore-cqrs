using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Paging;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Infrastructure.Paging;

namespace AspnetRun.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger)
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

        public async Task<IPagedList<CategoryModel>> SearchCategories(PageSearchArgs args)
        {
            var categoryPagedList = await _categoryRepository.SearchCategoriesAsync(args);

            var categoryModels = ObjectMapper.Mapper.Map<List<CategoryModel>>(categoryPagedList.Items);

            var categoryModelPagedList = new PagedList<CategoryModel>(
                categoryPagedList.PageIndex,
                categoryPagedList.PageSize,
                categoryPagedList.TotalCount,
                categoryPagedList.TotalPages,
                categoryModels);

            return categoryModelPagedList;
        }
    }
}
