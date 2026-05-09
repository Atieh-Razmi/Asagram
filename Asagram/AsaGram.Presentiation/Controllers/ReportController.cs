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
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly ISender _sender;
        public ReportController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportForCreateDTO reportDTO)
        {
            var report = await _sender.Send(new CreateReportCommand(reportDTO));
            return Ok(report);
        }

        [HttpGet]
        public async Task<IActionResult> GetReports([FromQuery] ReportParameters reportParameters)
        {
            var reports = await _sender.Send(new GetReportsQuery(reportParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(reports.MetaData));
            return Ok(new { Leaves = reports, MetaData = reports.MetaData });
        }
    }
}
