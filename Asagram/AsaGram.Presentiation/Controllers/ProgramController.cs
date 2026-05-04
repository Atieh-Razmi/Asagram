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
    [Route("api/program")]
    public class ProgramController :ControllerBase
    {
        private readonly ISender _sender;
        public ProgramController(ISender sender)
        {
            _sender = sender;   
        }

        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var result = await _sender.Send(new GetProgramsQuery());
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProgram([FromBody] ProgramForCreateDTO program)
        {
            var programEntity = await _sender.Send(new CreateProgramCommand(program));
            return Ok(programEntity);
        }

        [HttpPost("{id:guid}/edit")]
        public async Task<IActionResult> UpdateProgram(Guid id, [FromBody] ProgramForCreateDTO program)
        {
            var result = await _sender.Send(new UpdateProgramCommand(id, program));
            return NoContent();
        }
    }
}
