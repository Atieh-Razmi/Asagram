using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly ISender _sender;

        public ProfileController(ISender sender)
        {
            _sender = sender;

        }

        [HttpPost("{id:guid}/info")]
        public async Task<IActionResult> Profile(Guid id, [FromBody]ProfileCreateDTO profile)
        {
            var result = await _sender.Send(new CreateProfileCommand(id,profile));
            return Ok(result);
        }

        [HttpPost("{id:guid}/image")]
        public async Task<IActionResult> UploadProfileImage(Guid id, [FromForm] UploadFileDTO uploadImage)
        {
            var result = await _sender.Send(new CreateProfileImageCommand(id, uploadImage));
            return Ok(result);
        }
    }
}
