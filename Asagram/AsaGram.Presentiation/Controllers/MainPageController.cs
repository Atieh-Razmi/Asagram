using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/mainpage")]
    public class MainPageController : ControllerBase
    {
        private readonly ISender _sender;
        public MainPageController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn()
        {
            var result = await _sender.Send(new CreateCheckInCommand());
            return Ok(result);
        }
    }
}
