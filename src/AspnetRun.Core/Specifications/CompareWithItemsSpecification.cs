using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class CompareWithItemsSpecification : BaseSpecification<Compare>
    {
        public CompareWithItemsSpecification(string userName)
            : base(p => p.UserName.Contains(userName))
        {
            AddInclude(p => p.ProductCompares);
        }

        public CompareWithItemsSpecification(int compareId)
            : base(p => p.Id == compareId)
        {
            AddInclude(p => p.ProductCompares);
        }
    }
}
