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
    public class SearchCustomersQueryHandler : IRequestHandler<SearchCustomersQuery, SearchCustomersQueryResultDto>
    {
        private readonly ICustomerRepository _customerRepository;
        public SearchCustomersQueryHandler(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }
        public async Task<SearchCustomersQueryResultDto> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = new SearchCustomersQueryResultDto();
            var query = _customerRepository.GetAllCustomers();

            if(request.Filter?.FirstName != null)
            {
                query = query.Where(x => x.FirstName == request.Filter.FirstName.TrimEnd());
            }
            if(request.Filter?.LastName != null)
            {
                query = query.Where(x => x.LastName == request.Filter.LastName.TrimEnd());
            }
            if(request.Filter?.Address != null)
            {
                query = query.Where(x => x.Address == request.Filter.Address.TrimEnd());
            }
            if(request.Filter?.ContactNumber != null)
            {
                query = query.Where(x => x.ContactNumber == request.Filter.ContactNumber.TrimEnd());
            }

            var count = await query.CountAsync();

            var customers = await query
            .OrderByDescending(x => x.DateCreated)
            .Skip(request.PageSize * (request.PageIndex - 1))
            .Take(request.PageSize)
            .ToListAsync();

            var customerList = new List<GetCustomerQueryResultDto>();
            foreach(var customer in customers)
            {
                customerList.Add(new GetCustomerQueryResultDto()
                {
                    Address = customer.Address,
                    ContactNumber = customer.ContactNumber,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateCreated = customer.DateCreated,
                    CustomerID = customer.CustomerID,
                });
            }

            result.PageSize = request.PageSize;
            result.PageIndex = request.PageIndex;
            result.TotalCount = count;
            result.Results = customerList;

            return result;
                
            throw new NotImplementedException();
        }
    }
}
