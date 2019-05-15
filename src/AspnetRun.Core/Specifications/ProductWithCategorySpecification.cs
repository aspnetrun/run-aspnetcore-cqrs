using AspnetRun.Core.Entities;

namespace AspnetRun.Core.Specifications
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName)
            : base(p => p.Name.Contains(productName))
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(int categoryId)
            : base(p => p.CategoryId == categoryId)
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification()
            : base(null)
        {
            AddInclude(p => p.Category);
        }
    }
}
