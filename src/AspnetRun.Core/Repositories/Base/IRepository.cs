using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Repositories.Base
{
    public interface IRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
