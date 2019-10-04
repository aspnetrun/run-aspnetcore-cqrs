using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Paging;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Paging;
using AspnetRun.Infrastructure.Repository.Base;

namespace AspnetRun.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AspnetRunContext dbContext)
            : base(dbContext)
        {
        }

        public Task<IPagedList<Category>> SearchCategoriesAsync(PageSearchArgs args)
        {
            var query = Table;

            var orderByList = new List<Tuple<SortingOption, Expression<Func<Category, object>>>>();

            if (args.SortingOptions != null)
            {
                foreach (var sortingOption in args.SortingOptions)
                {
                    switch (sortingOption.Field)
                    {
                        case "id":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Category, object>>>(sortingOption, c => c.Id));
                            break;
                        case "name":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Category, object>>>(sortingOption, c => c.Name));
                            break;
                        case "description":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Category, object>>>(sortingOption, c => c.Description));
                            break;
                    }
                }
            }

            if (orderByList.Count == 0)
            {
                orderByList.Add(new Tuple<SortingOption, Expression<Func<Category, object>>>(new SortingOption { Direction = SortingOption.SortingDirection.ASC }, c => c.Id));
            }

            var filterList = new List<Tuple<FilteringOption, Expression<Func<Category, bool>>>>();

            if (args.FilteringOptions != null)
            {
                foreach (var filteringOption in args.FilteringOptions)
                {
                    switch (filteringOption.Field)
                    {
                        case "id":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Category, bool>>>(filteringOption, c => c.Id == (int)filteringOption.Value));
                            break;
                        case "name":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Category, bool>>>(filteringOption, c => c.Name.Contains((string)filteringOption.Value)));
                            break;
                        case "description":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Category, bool>>>(filteringOption, c => c.Description.Contains((string)filteringOption.Value)));
                            break;
                    }
                }
            }

            var categoryPagedList = new PagedList<Category>(query, new PagingArgs { PageIndex = args.PageIndex, PageSize = args.PageSize, PagingStrategy = args.PagingStrategy }, orderByList, filterList);

            return Task.FromResult<IPagedList<Category>>(categoryPagedList);
        }
    }
}
