using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class OverTime
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public Guid ProjectId { get; set; }

        public Project Project { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        

        public DateTime Date {  get; set; }
        public double Duration { get; set; }
        public OverTimeStatus OverTimeStatus { get; set; } = OverTimeStatus.Checking;
        public ICollection<OverTimeStep> OverTimeSteps { get; set; } = new List<OverTimeStep>();

    }
}
