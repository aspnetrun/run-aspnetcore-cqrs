using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class WishlistWithItemsSpecification : BaseSpecification<Wishlist>
    {
        public WishlistWithItemsSpecification(string userName)
            : base(p => p.UserName.Contains(userName))
        {
            AddInclude(p => p.ProductWishlists);
        }

        public WishlistWithItemsSpecification(int wishlistId)
            : base(p => p.Id == wishlistId)
        {
            AddInclude(p => p.ProductWishlists);
        }
    }
}
