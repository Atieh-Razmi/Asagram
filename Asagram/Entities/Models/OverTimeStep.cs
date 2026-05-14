using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class OverTimeStep
    {
        public Guid Id { get; set; }

        public Guid OverTimeId { get; set; }
        public OverTime OverTime { get; set; } = null!;

        public int OverTimeStepNumber { get; set; }
        public OverTimeStepStatus OverTimeStepStatus { get; set; }
        public Guid? ApproverId { get; set; }
        public User? Approver { get; set; }

        public DateTime Date { get; set; }
    }
}
