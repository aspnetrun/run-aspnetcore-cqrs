using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;

namespace AspnetRun.Core.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int DefaultAddressId { get; set; }
        public Address DefaultAddress { get; set; }
        public string Email { get; set; }
        public string CitizenId { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
