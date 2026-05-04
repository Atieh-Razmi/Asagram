using Application.Commands;
using Application.Queries;
using Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/communication")]
    public class CommunicationController : ControllerBase
    {
        private readonly ISender _sender;
        public CommunicationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunications()
        {
            var communications = await _sender.Send(new GetCommunicationsQuery());
            return Ok(communications);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCommunication([FromForm] UploadFileDTO uploadFileDTO)
        {
            if (uploadFileDTO.File == null)
                return BadRequest("File is required.");

            using var ms = new MemoryStream();
            await uploadFileDTO.File.CopyToAsync(ms);

            var communication = await _sender.Send(new UploadFileCommunicationCommand(
                uploadFileDTO.File.FileName, uploadFileDTO.File.ContentType, ms.ToArray(), FileType.Communication));

            return Ok(communication);
        }

        [HttpPost("{id:guid}/delete")]

        public async Task<IActionResult> DeleteCommunication(Guid id)
        {
            var communication = await _sender.Send(new DeleteCommnicationCommand(id));
            return NoContent();
        }

        [HttpGet("{id:guid}/download")]
        public async Task<IActionResult> Download(Guid id)
        {
            var file = await _sender.Send(new DownloadFileQuery(id));
            if (file == null)
                return NotFound("notfound file.");
            return File(file.Data, file.ContentType, file.Name);
        }
    }
}
