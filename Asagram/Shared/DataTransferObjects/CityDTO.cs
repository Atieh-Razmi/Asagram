using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CityDTO
    {
        public string? Name { get; set; }
        public string? ProvinceName { get; set; }
    }
}
