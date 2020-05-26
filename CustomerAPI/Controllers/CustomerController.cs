using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/bands")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();

            var customerDto = new List<CustomerDto>();
            foreach (var item in customers)
            {
                customerDto.Add(new CustomerDto
                {
                    PersonalNumber = item.PersonalNumber,
                    Email = item.Email,
                    CustomerId = item.CustomerId,
                    Address = new AddressDto
                    {
                        ZipCode = item.Address.ZipCode,
                        Country = item.Address.Country.CountryName
                    },
                    PhoneNumber = new PhoneNumberDto
                    {
                        countryCode = item.PhoneNumber.Country.CountryCode,
                        phone = item.PhoneNumber.Phone
                    }
                });
            }
            return Ok(customerDto);
        }
    }
}
