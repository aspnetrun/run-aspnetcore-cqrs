using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface ICompareRepository : IRepository<Compare>
    {
        Task<Compare> GetByUserNameAsync(string userName);
    }
}
