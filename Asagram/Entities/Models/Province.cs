using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Province
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<City> cities { get; set; } = new List<City>();
    }
}
