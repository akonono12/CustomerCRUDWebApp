using CustomerCRUDWebApp.Application.Customers.Commands;
using CustomerCRUDWebApp.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCRUDWebApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] GetCustomerQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCustomers([FromQuery] SearchCustomersQuery request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
