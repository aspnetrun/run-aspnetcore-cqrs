using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class ProductSpecification : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }
    }
}
