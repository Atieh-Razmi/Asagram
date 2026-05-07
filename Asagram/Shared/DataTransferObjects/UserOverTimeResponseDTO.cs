using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserOverTimeResponseDTO
    {
        public Guid ProjectId { get; set; }
        public DateTime Date { get; set; }
        public Double Duration { get; set; }
        public string Description { get; set; } = null!;
        public OverTimeStatus OverTimeStatus { get; set; }
    }
}
