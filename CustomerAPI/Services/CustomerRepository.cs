using CustomerAPI.DBContexts;
using CustomerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerAPI.Services
{
    class CustomerRepository : ICustomerRepository
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

        public Customer GetCustomer(long personalNumber)
        {
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));

            return _context.Customers.Where(customer => customer.PersonalNumber == personalNumber).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            var personalNumber = customer.PersonalNumber;
            if (personalNumber.ToString().Length < 10 || personalNumber.ToString().Length > 12)
                throw new InvalidOperationException(nameof(personalNumber));


        }
    }
}
