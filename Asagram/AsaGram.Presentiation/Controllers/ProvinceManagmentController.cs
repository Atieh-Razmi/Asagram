using Application.Commands;
using Application.Queries;
using Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;


namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProvinceManagmentController : ControllerBase
    {
        private readonly ISender _sender;
        public ProvinceManagmentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("provinces")]
        public async Task<IActionResult> CreateProvince([FromBody] ProvinceDTO provinceDTO)
        {
            var provinces = await _sender.Send(new CreateProvinceCommand(provinceDTO));
            return NoContent();
        }

        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces([FromQuery] ProvinceParameters provinceParameters)
        {
            var pagelist = await _sender.Send(new GetProvincesQuery(provinceParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagelist.MetaData));
            return Ok(new { Provinces = pagelist, MetaData = pagelist.MetaData });
        }

        

        //delete province

        [HttpPost("province/{id:guid}/delete")]

        public async Task<IActionResult> DeleteProvince(Guid id)
        {
            var province = await _sender.Send(new DeleteProvinceCommand(id, TrackChanges:false));
            return NoContent();
        }

        //update province

        [HttpPost("province/{id:guid}/update")]

        public async Task<IActionResult> UpdateProvince(Guid id, ProvinceDTO provinceDTO)
        {
            var province = await _sender.Send(new UpdateProvinceCommand(id, provinceDTO));
            return NoContent();
        }

        [HttpPost("city")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityDTO cityDTO)
        {
            var cities = await _sender.Send(new CreateCityCommand(cityDTO));
            return NoContent();
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities([FromQuery] CityParameters cityParameters)
        {
            var pagelist = await _sender.Send(new GetCitiesQuery(cityParameters));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagelist.MetaData));
            return Ok(new { Provinces = pagelist, MetaData = pagelist.MetaData });
        }

        //update city

        [HttpPost("cities/{id:guid}/update")]
        public async Task<IActionResult> UpdateCity(Guid id,[FromBody] CityForUpdateDTO city)
        {
            var result = await _sender.Send(new UpdateCityCommand(id, city));
            return NoContent();
        }

        //delete city
        [HttpPost("cities/{id:guid}/delete")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var result = await _sender.Send(new DeleteCityCommand(id));
            return NoContent();
        }
    }
}
