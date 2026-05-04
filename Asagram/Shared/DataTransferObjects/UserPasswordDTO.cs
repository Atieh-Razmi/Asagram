using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserPasswordDTO 
    { 
        public Guid Id { get; set; }
        public string Password { get; set; }
    }
    
}
