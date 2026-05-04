using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record PasswordDTO
    {
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }

    
}
