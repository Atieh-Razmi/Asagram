using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ProvinceresponseDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
