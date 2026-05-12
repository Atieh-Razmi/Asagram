using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class LeaveStep
    {
        public Guid Id { get; set; }

        public Guid LeaveId { get; set; }
        public Leave Leave { get; set; } = null!;
        
        public int LeaveStepNumber { get; set; }
        public LeaveStepStatus LeaveStepStatus { get; set; }
        public Guid? ApproverId { get; set; }
        public User? Approver { get; set; }

        public DateTime Date { get; set; }
    }
}
