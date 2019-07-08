using AspnetRun.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace AspnetRun.Core.Entities
{
    public class AspnetRunRole : IdentityRole<int>, IEntityBase<int>
    {
    }
}
