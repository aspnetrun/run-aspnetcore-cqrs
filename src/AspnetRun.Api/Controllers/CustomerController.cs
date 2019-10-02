using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspnetRun.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerService _customerService;

        public CustomerController(IMediator mediator, ICustomerService customerService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            //var categories = await _customerService.GetCustomerList();

            var customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    Id = 1,
                    FirstName = "mehmet",
                    LastName = "ozkaya",
                    Address = "gungoren",
                    City = "istanbul",
                    Description = "asdf",
                    State = "success",
                    OrderTotal = 22.2
                },
                new CustomerModel
                {
                    Id = 2,
                    FirstName = "merve",
                    LastName = "ozkaya",
                    Address = "gungoren",
                    City = "istanbul",
                    Description = "asdf",
                    State = "success",
                    OrderTotal = 22.2
                },
                new CustomerModel
                {
                    Id = 3,
                    FirstName = "zeynep",
                    LastName = "ozkaya",
                    Address = "gungoren",
                    City = "istanbul",
                    Description = "asdf",
                    State = "success",
                    OrderTotal = 22.2
                },
            };

            return Ok(customers);
        }
    }
}
