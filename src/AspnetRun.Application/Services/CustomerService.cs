using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CustomerService : ICustomerService
    {
        //private readonly IRepository<Customer> _customerRepository;
        //private readonly IAppLogger<CustomerService> _logger;

        //public CustomerService(IRepository<Customer> customerRepository, IAppLogger<CustomerService> logger)
        //{
        //    _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        //public async Task<IEnumerable<CustomerModel>> GetCustomerList()
        //{
        //    var customerList = await _customerRepository.ListAllAsync();

        //    var customerModels = ObjectMapper.Mapper.Map<IEnumerable<CustomerModel>>(customerList);

        //    return customerModels;
        //}
        public Task<IEnumerable<CustomerModel>> GetCustomerList()
        {
            throw new NotImplementedException();
        }
    }

}
