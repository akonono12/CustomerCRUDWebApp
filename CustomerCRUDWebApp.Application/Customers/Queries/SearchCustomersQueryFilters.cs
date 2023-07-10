using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Application.Customers.Queries
{
    public class SearchCustomersQueryFilters
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
    }
}
