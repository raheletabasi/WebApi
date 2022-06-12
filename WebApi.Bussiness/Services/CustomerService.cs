using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Bussiness.Services.Interfaces;
using WebApi.Data.Context;
using WebApi.Data.Entities;

namespace WebApi.Bussiness.Services
{
    public class CustomerService : ICustomerService
    {
        WebApi_DBContext _context;

        public CustomerService(WebApi_DBContext context)
        {
            _context = context;
        }

        public Customer DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            _context.Customers.Remove(customer);
            _context.SaveChangesAsync();
            return customer;            
        }

        public bool ExistCustomer(int customerId)
        {
            return _context.Customers.Any(c => c.CustomerId == customerId);
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);
        }

        public void InsertCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChangesAsync();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChangesAsync();    
        }
    }
}
