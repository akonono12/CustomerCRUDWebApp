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
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAllCustomers()
                .SingleOrDefaultAsync(x => x.CustomerID == request.Id);

            if (customer == null)
            {
                return false;
            }

            customer.Delete();

            await _customerRepository.SaveChangesAsync();
            return true;
        }
    }
}
