using AspnetRun.Application.Models;
using AspnetRun.Core.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();

        Task<IPagedList<CategoryModel>> SearchCategories(PageSearchArgs args);
    }
}
