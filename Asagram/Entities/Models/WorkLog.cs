using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class WorkLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime TotalDate { get; set; }

        public DateTime Date {  get; set; }

    }
}
