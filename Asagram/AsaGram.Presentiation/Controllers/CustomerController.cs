using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController :ControllerBase
    {
        private readonly ISender _sender;
        public CustomerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _sender.Send(new GetCustomersQuery());
            return Ok(customers);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _sender.Send(new GetCustomerQuery(id));
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreateDTO customerForCreateDTO)
        {
            var customer = await _sender.Send(new CreateCustomerCommand(customerForCreateDTO));
            return Ok(customer);
        }

        [HttpPost("{id:guid}/delete")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _sender.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }

        [HttpPost("{id:guid}/update")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerForCreateDTO updateCustomer)
        {
            var customer = await _sender.Send(new UpdateCustomerCommand(id, updateCustomer));
            return NoContent();
        }
    }
}
