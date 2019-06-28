using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;

namespace AspnetRun.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
}
