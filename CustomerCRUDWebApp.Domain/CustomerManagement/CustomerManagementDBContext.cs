using CustomerCRUDWebApp.Domain.CustomerManagement.Configurations;
using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Domain.CustomerManagement
{
    public class CustomerManagementDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerManagementDBContext(DbContextOptions<CustomerManagementDBContext>
        options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

    }
}
