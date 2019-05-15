using AspnetRun.Core.Entities.Base;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Infrastructure.Data;

namespace AspnetRun.Infrastructure.Repository.Base
{
    public class Repository<T> : RepositoryBase<T, int>, IRepository<T>
        where T : class, IEntityBase<int>
    {
        public Repository(AspnetRunContext context)
            : base(context)
        {
        }
    }
}
