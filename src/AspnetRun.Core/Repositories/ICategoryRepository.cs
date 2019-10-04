using AspnetRun.Core.Entities;
using AspnetRun.Core.Paging;
using AspnetRun.Core.Repositories.Base;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IPagedList<Category>> SearchCategoriesAsync(PageSearchArgs args);
    }
}
