using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Domain.CustomerManagement.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        Task SaveChangesAsync();

    }
}
