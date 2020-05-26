using AutoMapper;
using CustomerAPI.Entities;
using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await Task.FromResult(_customerRepository.GetCustomers()).Result;
            if (customers == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        [HttpGet("{customerId}", Name ="GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var customer = await Task.FromResult(_customerRepository.GetCustomer(customerId)).Result;
            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer([FromBody] CustomerCreateDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            _customerRepository.CreateCustomer(customerEntity);

            var band = _mapper.Map<CustomerDto>(customerEntity);

            return CreatedAtRoute("GetCustomer", new { customerId = band.CustomerId }, band);
        }
    }
}
