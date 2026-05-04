using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public class ProjectDTO
    {
        
        public string Title { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public string? Description { get; set; }
    }
}
