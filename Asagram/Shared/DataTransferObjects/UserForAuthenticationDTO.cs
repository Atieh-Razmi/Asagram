using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserForAuthenticationDTO
    {
        [Required(ErrorMessage ="User Name is Required.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage ="Password Name is Required.")]
        public string? Password { get; init; }
    }
}
