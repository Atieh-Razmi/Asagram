using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record OverTimeForCreateDTO
    {
        public Guid ProjectId { get; set; }
        public DateTime Date {  get; set; }
        public Double Duration { get; set; }
        public string Description { get; set; } = null!;
    }
}
