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
    [Route("api/leave")]
    public class LeaveController : ControllerBase
    {
        private readonly ISender _sender;
        public LeaveController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeave([FromBody] LeaveForCreateDTO leaveDTO)
        {
            var leave = await _sender.Send(new CreateLeaveCommand(leaveDTO));
            return Ok(leave);
        }

        [HttpGet("admin-page")]
        public async Task<IActionResult> GetLeaves([FromQuery]AdminLeaveParameters adminLeaveParameters)
        {
            var results = await _sender.Send(new GetAdminLeavesQuery(adminLeaveParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.MetaData));

            return Ok(new { Leaves = results, MetaData = results.MetaData });
        }

        [HttpGet("user-page")]
        public async Task<IActionResult> GetUserLeaves([FromQuery] UserLeaveParameters userLeaveParameters)
        {
            var results = await _sender.Send(new GetUserSideLeavesQuery(userLeaveParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(results.MetaData));
            return Ok(new { Leaves = results, MetaData = results.MetaData });
        }

        [HttpPost("{id:guid}")]
        public async Task<IActionResult> UpdateLeaveStatus(Guid id, [FromBody] StatusDTO status)
        {
            var result = await _sender.Send(new UpdateLeaveStatusCommand(id, status));
            return NoContent();
        }

        [HttpPost("{id:guid}/delete")]
        public async Task<IActionResult> DeleteLeave(Guid id)
        {
            var leave = await _sender.Send(new DeleteLeaveCommand(id));
            return NoContent();
        }
        
    }
}
