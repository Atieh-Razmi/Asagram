using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Leave
    {
        public Guid Id { get; set; }

        public LeaveType LeaveType { get; set; }

        public LeaveTime LeaveTime { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Description { get; set; }
        public decimal Duration { get; set; }
        public LeaveStatus LeaveStatus { get; set; } = LeaveStatus.Checking;

        public required User User { get; set; } 
        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //utc????
        public DateTime? UpdatedAt { get; set; }
        public ICollection<LeaveStep> LeaveSteps { get; set; } = new List<LeaveStep>();
    }
}
