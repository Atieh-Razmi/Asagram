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
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly ISender _sender;
        public ProjectController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDTO project)
        {
            var result = await _sender.Send(new CreateProjectCommand(project));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _sender.Send(new GetProjectsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _sender.Send(new GetProjectQuery(id));
            return Ok(project);
        }
        [HttpPost("{id:guid}/edit")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectDTO project)
        {
            var result = await _sender.Send(new UpdateProjectCommand(id, project));
            return NoContent();
        }
             
    }
}
