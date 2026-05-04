using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CityForUpdateDTO
    {
        [Required(ErrorMessage ="name of city is required.")]
        public string? Name { get; set; }
    }
}
