using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime Date { get; set;  }
    }
}
