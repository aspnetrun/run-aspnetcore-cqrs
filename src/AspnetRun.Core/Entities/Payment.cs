using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;

namespace AspnetRun.Core.Entities
{
    public class Payment : Entity
    {
        public decimal GrandTotal { get; set; }

        public List<PaymentItem> Items { get; set; } = new List<PaymentItem>();
    }
}
