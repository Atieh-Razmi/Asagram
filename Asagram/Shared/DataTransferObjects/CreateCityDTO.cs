using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CreateCityDTO
    { 
        [Required(ErrorMessage ="name of city is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "id of province is required.")]

        //[SwaggerSchema(Description = "Province ID", Example = "11111111-1111-1111-1111-111111111111")]
        public Guid ProvinceId { get; set; }

    }
}
