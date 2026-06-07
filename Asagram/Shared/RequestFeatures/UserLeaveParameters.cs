using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.RequestFeatures
{
    public class UserLeaveParameters : RequestParameters
    {
        public LeaveStatus? LeaveStatus { get; set; }
        public LeaveTime? LeaveTime { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
