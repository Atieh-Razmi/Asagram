using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
