using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AsaGram.Presentiation.Controllers
{
    [Route("api/usermanagement")]
    [ApiController]
    public class UserManagementController: ControllerBase
    {
        private readonly ISender _sender;
        public UserManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
        {
            var (users, meta) = await _sender.Send(new GetUsersQuery(userParameters,TrackChanges: false));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(meta));
            return Ok(new {Users = users, MetaData=meta });
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _sender.Send(new GetUserQuery(id));
            return Ok(user);
        }


        [HttpPost("{id:guid}/setpassword")]
        //[Authorize]
        public async Task<IActionResult> SetPassword(Guid id,[FromBody] PasswordDTO passwordDTO)
        {
            var password = await _sender.Send(new SetPasswordCommand(id,passwordDTO));
            return Ok(password);
        }

        [HttpPost("{id:guid}/update")]
        public async Task<IActionResult> UpdateUser(Guid id,[FromBody] UserForUpdateDTO userUpdate)
        {
            var user = await _sender.Send(new UpdateUserCommand(id, userUpdate, TrackChanges:true));
            return NoContent();
        }

        [HttpPost("{id:guid}/isactive")]
        public async Task<IActionResult> ChangeUserStatus(Guid id, [FromBody] IsActiveDTO isActive)
        {
            var user = await _sender.Send(new ChangeUserStatusCommand(id, isActive));
            return NoContent();
        }

        
    }
}
