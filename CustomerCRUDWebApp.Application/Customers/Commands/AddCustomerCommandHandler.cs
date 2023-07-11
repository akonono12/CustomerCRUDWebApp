using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;
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
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        public AddCustomerCommandHandler(ICustomerRepository customerRepository) 
        { 
            _customerRepository = customerRepository;
        }
        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.FirstName,request.LastName,request.Address,request.ContactNumber);

            var hasSameName =await _customerRepository.GetAllCustomers()
                .AnyAsync(x => x.FirstName == request.FirstName
                            && x.LastName == request.LastName);
            if (hasSameName)
            {
                return Guid.Empty;
            }
            _customerRepository.AddCustomer(customer);
            await _customerRepository.SaveChangesAsync();
            return customer.CustomerID;
        }
    }
}
