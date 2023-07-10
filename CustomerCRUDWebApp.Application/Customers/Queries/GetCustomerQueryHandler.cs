using CustomerCRUDWebApp.Domain.CustomerManagement.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Application.Customers.Queries
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResultDto>
    {
       private readonly ICustomerRepository _customerRepository;
       public GetCustomerQueryHandler(ICustomerRepository customerRepository) 
       {
            _customerRepository = customerRepository;
       }
       public async Task<GetCustomerQueryResultDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
       {
            var result = new GetCustomerQueryResultDto();

            var customer = await _customerRepository.GetAllCustomers()
                .SingleOrDefaultAsync(x => x.CustomerID == request.Id);

            if (customer != null)
            {
                result.ContactNumber = customer.ContactNumber;
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
                result.Address = customer.Address;
                result.DateCreated = customer.DateCreated;
                result.CustomerID = customer.CustomerID;
            }
            return result;


       }
    }
}
