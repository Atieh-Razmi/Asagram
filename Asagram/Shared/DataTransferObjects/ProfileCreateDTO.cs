using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ProfileCreateDTO
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? NationalCode { get; set; }
        public string? UserUnit {  get; set; }
        public string? RoleName { get; set; }

        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }

    }
}
