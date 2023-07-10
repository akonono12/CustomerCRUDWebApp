using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;
using CustomerCRUDWebApp.Domain.CustomerManagement.Interfaces;
using MediatR;
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
            _customerRepository.AddCustomer(customer);
            await _customerRepository.SaveChangesAsync();
            return customer.CustomerID;
        }
    }
}
