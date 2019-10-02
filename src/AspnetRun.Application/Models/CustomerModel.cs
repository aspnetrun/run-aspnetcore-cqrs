using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class CustomerModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double OrderTotal { get; set; }
        public string Description { get; set; }
    }
}
