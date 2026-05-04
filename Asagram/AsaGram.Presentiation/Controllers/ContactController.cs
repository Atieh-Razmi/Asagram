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
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly ISender _sender;
        public ContactController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var results = await _sender.Send(new GetContactsQuery());
            return Ok(results);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var result = await _sender.Send(new GetContactQuery(id));
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactForCreateDTO contactForCreate)

        {
            var contact = await _sender.Send(new CreateContactCommand(contactForCreate));
            return Ok(contact);
        }

        [HttpPost("{id:guid}/delete")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var contact = await _sender.Send(new DeleteContactCommand(id));
            return NoContent();
        }

        [HttpPost("{id:guid}/update")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] ContactDTO contactDTO)
        {
            var contact = await _sender.Send(new UpdateContactCommand(id, contactDTO));
            return NoContent();
        }
    }
}
