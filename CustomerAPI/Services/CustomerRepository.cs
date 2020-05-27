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

            var personalNumber = customer.PersonalNumber;
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));

            var customerId = Guid.NewGuid();

            customer.CustomerId = customerId;
            customer.Address.CustomerId = customerId;
            customer.Address.AddressId = Guid.NewGuid();

            //var address = new Address
            //{
            //    AddressId = Guid.NewGuid(),
            //    Country = customer.Address.Country,
            //    CustomerId = customerId,
            //    ZipCode = customer.Address.ZipCode
            //};


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

            //if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
            //    throw new InvalidOperationException(nameof(personalNumber));

            // return await _context.Customers.Where(customer => customer.CustomerId == customerId).FirstOrDefaultAsync();

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
            var personalNumber = customer.PersonalNumber;
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));


        }

        //public async Task<bool> IsValidCountry(string country)
        //{
        //    if (country == null)
        //        throw new ArgumentNullException(nameof(country));

        //    var existingCountry = await _context.Countries.Where(countries => countries.CountryName == country).ToListAsync();
        //    if (!existingCountry.Any())
        //        return false;
        //    else
        //        return true;
        //}
    }
}
