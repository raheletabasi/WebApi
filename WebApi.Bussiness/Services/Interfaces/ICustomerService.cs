using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Entities;

namespace WebApi.Bussiness.Services.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomer();
        Customer GetCustomerById(int customerId);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Customer DeleteCustomer(int customerId);

        bool ExistCustomer(int customerId);
    }
}
