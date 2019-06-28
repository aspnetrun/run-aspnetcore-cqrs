using System.Threading.Tasks;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;

namespace AspnetRun.Core.Repositories
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Task<Wishlist> GetByUserNameAsync(string userName);
    }
}
