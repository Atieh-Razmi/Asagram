using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record RoleResponseDTO
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
    }
}
