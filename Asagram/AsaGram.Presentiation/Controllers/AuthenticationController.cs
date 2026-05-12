using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly ISender _sender;
        public AuthenticationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDTO user)
        {
            var result = await _sender.Send(new LoginCommand(user));
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDTO token)
        {
            var result = await _sender.Send(new RefreshTokenCommand(token));
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDTO user)
        {
            var result = await _sender.Send(new RegisterUserCommand(user));
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _sender.Send(new LogoutUserCommand());
            return NoContent();
        }

        [HttpPost("Createrole")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO role)
        {
            var result = await _sender.Send(new CreateRoleCommand(role));
            return Ok(result);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _sender.Send(new GetRolesQuery());
            return Ok(result);
        }

        [HttpPost("CreateUnit")]
        public async Task<IActionResult> CreateUnit([FromBody] CreateUnitDTO unit)
        {
            var result = await _sender.Send(new CreateUnitCommand(unit));
            return Ok(result);
        }

        [HttpGet("units")]
        public async Task<IActionResult> GetUnits()
        {
            var result = await _sender.Send(new GetUnitsQuery());
            return Ok(result);
        }

    }
}
