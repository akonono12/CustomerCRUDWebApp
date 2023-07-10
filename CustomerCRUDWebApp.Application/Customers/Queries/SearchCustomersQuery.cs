using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Application.Customers.Queries
{
    public class SearchCustomersQuery :IRequest<SearchCustomersQueryResultDto>
    {
        public SearchCustomersQueryFilters? Filter { get; set; }
        public int PageIndex { get; set; }
        public int PageSize => 10;
    }
}
