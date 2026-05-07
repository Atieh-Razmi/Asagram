using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record OverTimeResponseDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
    }
}
