using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;

namespace AspnetRun.Infrastructure.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> GetByCustomerIdAsync(int customerId)
        {
            var spec = new CartWithItemsSpecification(customerId);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
