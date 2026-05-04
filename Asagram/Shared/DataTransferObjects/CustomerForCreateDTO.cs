using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CustomerForCreateDTO
    {
        public string Title { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PostalCode { get; set; }

        public Guid CityId { get; set; }
        public Guid ProvinceId { get; set; }
        public List<string> PhoneNumbers { get; set; } = new();
    }
}
