using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;

namespace CustomerCRUDWebApp.Domain.CustomerManagement.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);
            builder.HasQueryFilter(x => x.DateDeleted == null);
        }
    }
}
