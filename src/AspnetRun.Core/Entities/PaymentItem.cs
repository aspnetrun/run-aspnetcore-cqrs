using AspnetRun.Core.Entities.Base;

namespace AspnetRun.Core.Entities
{
    public class PaymentItem : Entity
    {
        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }
    }

    public enum PaymentMethod
    {
        Cash = 1,
        CreditCard = 2,
        Check = 3,
        BankTransfer = 4,
        Paypal = 5,
        Payoneer = 6
    }
}
