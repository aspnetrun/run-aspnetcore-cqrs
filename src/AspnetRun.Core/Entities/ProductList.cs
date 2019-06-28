using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class ProductList : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ListId { get; set; }
        public List List { get; set; }
    }
}
