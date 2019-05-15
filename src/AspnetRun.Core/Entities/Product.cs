using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
