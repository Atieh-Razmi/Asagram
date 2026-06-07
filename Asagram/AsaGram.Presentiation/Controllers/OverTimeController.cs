using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/overtime")]
    public class OverTimeController : ControllerBase
    {
        private readonly ISender _sender;
        public OverTimeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOverTime([FromBody] OverTimeForCreateDTO overTimeDTO)
        {
            var overtime = await _sender.Send(new CreateOverTimeCommand(overTimeDTO));
            return Ok(overtime);
        }

        [HttpGet("user-side")]
        public async Task<IActionResult> GetOverTimesUser([FromQuery] UserOverTimeParameters userOverTimeParameters)
        {
            var results = await _sender.Send(new GetOverTimesUserQuery(userOverTimeParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.MetaData));
            return Ok(new { OverTimes = results, MetaData = results.MetaData });
        }

        [HttpGet("admin-side")]
        //[Authorize(Roles = "admin")]
        
        public async Task<IActionResult> GetOverTimesAdmin([FromQuery] AdminOverTimeParameters adminOverTimeParameters)
        {
            var results = await _sender.Send(new GetOverTimesAdminQuery(adminOverTimeParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.MetaData));
            return Ok(new { OverTimes = results, MetaData = results.MetaData });
        }




        [HttpPost("{id:guid}")]
        public async Task<IActionResult> UpdateOverTimeStatus(Guid id, [FromBody] OverTimeStatusDTO overTimeStatusDTO)
        {
            var overTime = await _sender.Send(new UpdateOverTimeStatusCommand(id, overTimeStatusDTO));
            return Ok(overTime);
        }

        [HttpPost("{id:guid}/delete")]
        public async Task<IActionResult> DeleteOverTime(Guid id)
        {
            var overTime = await _sender.Send(new DeleteOverTimeCommand(id));
            return NoContent();
        }

    }
}
