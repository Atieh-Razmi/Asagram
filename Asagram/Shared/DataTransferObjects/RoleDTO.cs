using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record RoleDTO
    {
        public string RoleName { get; set; } = null!;
    }
}
