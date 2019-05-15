using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Repositories.Base
{
    public interface IEnumRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
