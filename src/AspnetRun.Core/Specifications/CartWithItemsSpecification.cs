using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class CartWithItemsSpecification : BaseSpecification<Cart>
    {
        public CartWithItemsSpecification(int customerId)
            : base(p => p.CustomerId == customerId)
        {
            AddInclude(p => p.Items);
        }
    }
}
