using Application.Commands;
using Application.Queries;
using MediatR;
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
            return Ok(new { Leaves = results, MetaData = results.MetaData });
        }
    }
}
