using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Unit
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public Guid? ManagerId { get; set; }
        [JsonIgnore]

        public User? Manager { get; set; }

        public Guid? ParentUnitId { get; set; }
        [JsonIgnore]

        public Unit? ParentUnit { get; set; }
        public ICollection<Unit> ChildUnits { get; set; } = new List<Unit>();

    }
}
