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

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;            
        }

        public async Task<bool> ExistCustomer(int customerId)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _context.Customers.Include(c => c.Order).SingleOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<Customer> InsertCustomer(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
             _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
