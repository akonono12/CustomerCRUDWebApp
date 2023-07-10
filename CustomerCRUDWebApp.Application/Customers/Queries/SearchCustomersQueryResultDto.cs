using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Application.Customers.Queries
{
    public class SearchCustomersQueryResultDto
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public List<GetCustomerQueryResultDto> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
