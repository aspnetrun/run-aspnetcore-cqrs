using AspnetRun.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomerList();
    }
}
