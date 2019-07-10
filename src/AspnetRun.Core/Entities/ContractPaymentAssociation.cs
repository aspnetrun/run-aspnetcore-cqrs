using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class ContractPaymentAssociation : Entity
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
