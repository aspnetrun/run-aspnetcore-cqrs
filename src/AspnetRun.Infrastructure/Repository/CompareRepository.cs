using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class CompareRepository : Repository<Compare>, ICompareRepository
    {
        public CompareRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Compare> GetByUserNameAsync(string userName)
        {
            var spec = new CompareWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
