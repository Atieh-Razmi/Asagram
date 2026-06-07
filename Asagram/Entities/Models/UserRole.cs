using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }
    }
}
