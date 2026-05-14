using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserInfoDTO
    {
        public Guid Id { get; set; }
        public string fullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public Guid UnitId { get; set; }
        public string unitName { get; set; } = null!;

        public Guid RoleId { get; set; }
        public string roleName { get; set; } = null!;
    }
}
