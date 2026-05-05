using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public class ProjectResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public string? Description { get; set; }
    }
}
