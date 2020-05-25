using CustomerAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Services
{
    interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(long personalNumber);

        void CreateCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
    }
}
