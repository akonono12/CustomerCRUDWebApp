using CustomerCRUDWebApp.Domain.CustomerManagement.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDWebApp.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetAllCustomers()
                .ToListAsync();

            var customer = result.SingleOrDefault(x => x.CustomerID == request.CustomerID);
            if (customer == null)
            {
                return false;
            }


            var hasSameName = result.Any(x => x.CustomerID != request.CustomerID
                                         && x.FirstName == request.FirstName
                                         && x.LastName == request.LastName);
            if (hasSameName) {
                return false;
            }

            customer.Update(request.FirstName,request.LastName,request.Address,request.ContactNumber);

            await _customerRepository.SaveChangesAsync();
            return true;
        }
    }
}
