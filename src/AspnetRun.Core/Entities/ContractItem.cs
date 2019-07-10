using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class ContractItem : Entity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
