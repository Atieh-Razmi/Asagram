using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record StatusDTO
    {
        public LeaveStatus Status { get; set; }
    }
}
