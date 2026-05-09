using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record AdminLeaveResponseDTO
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; } = null!;
        public LeaveTime LeaveTime { get; init; }
        public LeaveType LeaveType { get; init; }
        public string? Description { get; init; }
        public DateTime FromDate { get; init; }
        public DateTime ToDate { get; init; }
    }
}
