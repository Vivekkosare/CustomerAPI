using CustomerAPI.DBContexts;
using CustomerAPI.Entities;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async void CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var customerId = Guid.NewGuid();

            customer.CustomerId = customerId;
            customer.Address.CustomerId = customerId;
            customer.Address.AddressId = Guid.NewGuid();

            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            if (customerId == null)
                throw new ArgumentNullException(nameof(customerId));

            var customer = await (from cust in _context.Customers
                                  join address in _context.Addresses on cust.CustomerId equals address.CustomerId
                                  select new Customer
                                  {
                                      Address = new Address
                                      {
                                          ZipCode = address.ZipCode,
                                          Country = address.Country,
                                          AddressId = address.AddressId
                                      },
                                      PhoneNumber = cust.PhoneNumber,
                                      CustomerId = cust.CustomerId,
                                      Email = cust.Email,
                                      PersonalNumber = cust.PersonalNumber
                                  }).Where(customer => customer.CustomerId == customerId).FirstOrDefaultAsync();

            return customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await (from cust in _context.Customers
                                   join address in _context.Addresses on cust.CustomerId equals address.CustomerId
                                   select new Customer
                                   {
                                       Address = new Address
                                       {
                                           ZipCode = address.ZipCode,
                                           Country = address.Country,
                                           AddressId = address.AddressId
                                       },
                                       PhoneNumber = cust.PhoneNumber,
                                       CustomerId = cust.CustomerId,
                                       Email = cust.Email,
                                       PersonalNumber = cust.PersonalNumber
                                   }).ToListAsync<Customer>();

            return customers ?? throw new ArgumentNullException(nameof(customers));
        }

        
        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
