using AspnetRun.Core.Entities.Base;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Infrastructure.Data;

namespace AspnetRun.Infrastructure.Repository.Base
{
    public class EnumRepository<T> : RepositoryBase<T, int>, IEnumRepository<T>
        where T : class, IEntityBase<int>
    {
        public EnumRepository(AspnetRunContext context)
            : base(context)
        {
        }
    }
}
