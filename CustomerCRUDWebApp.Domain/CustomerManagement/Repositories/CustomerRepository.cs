using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;
using CustomerCRUDWebApp.Domain.CustomerManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Domain.CustomerManagement.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly CustomerManagementDBContext _dbContext;
        public CustomerRepository(CustomerManagementDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            var result = _dbContext.Customers;
            return result.AsQueryable();
        }

        public  void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
        }

        public async void SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
