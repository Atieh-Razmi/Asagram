using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/worklog")]
    public class WorkLogController : ControllerBase
    {
        private readonly ISender _sender;
        public WorkLogController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkLogs([FromQuery]WorkLogParameters workLogParameters)
        {
            var result = await _sender.Send(new GetWorkLogsQuery(workLogParameters));
            return Ok(result);
        }
    }
}
