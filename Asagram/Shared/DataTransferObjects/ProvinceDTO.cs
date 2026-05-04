using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ProvinceDTO
    {
        [Required(ErrorMessage = "name of Province is required.")]
        [MaxLength(50)]
        public String? Name {  get; set; }
    }
}
