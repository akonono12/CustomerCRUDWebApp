using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Application.Customers.Queries
{
    public class GetCustomerQuery:IRequest<GetCustomerQueryResultDto>
    {
        public Guid Id { get; set; }
    }
}
