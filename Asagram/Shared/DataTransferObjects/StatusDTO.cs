using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record StatusDTO
    {
        public LeaveStepStatus Status { get; set; }
    }
}
