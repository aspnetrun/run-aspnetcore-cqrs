using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class OrderPaymentAssociation : Entity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
