using CustomerAPI.DBContexts;
using CustomerAPI.Entities;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CustomerAPI.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void CreateCustomer(Customer customer)
        {
            var personalNumber = customer.PersonalNumber;
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomer(string personalNumber)
        {
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));

            return _context.Customers.Where(customer => customer.PersonalNumber == personalNumber).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = (from cust in _context.Customers
                             join address in _context.Addresses on cust.CustomerId equals address.CustomerId
                             join country in _context.Countries on address.CountryId equals country.CountryId
                             join phone in _context.PhoneNumbers on cust.CustomerId equals phone.CustomerId
                             select new Customer
                             {
                                 Address = new Address
                                 {
                                     ZipCode = address.ZipCode,
                                     Country = new Country
                                     {
                                         CountryName = country.CountryName,
                                         CountryCode = country.CountryCode,
                                         CountryId = country.CountryId
                                     },
                                     AddressId = address.AddressId
                                 },
                                 PhoneNumber = new PhoneNumber
                                 {
                                     PhoneId = phone.PhoneId,
                                     Phone = phone.Phone,
                                     Country = new Country
                                     {
                                         CountryName = country.CountryName,
                                         CountryCode = country.CountryCode,
                                         CountryId = country.CountryId
                                     },
                                     CountryId = country.CountryId
                                 },
                                 CustomerId = cust.CustomerId,
                                 Email = cust.Email,
                                 PersonalNumber = cust.PersonalNumber
                             });

            return customers.ToList() ?? throw new ArgumentNullException(nameof(customers));
        }

        public void UpdateCustomer(Customer customer)
        {
            var personalNumber = customer.PersonalNumber;
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));


        }
    }
}
