using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record WorkLogDTO
    {
        public string FullName { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public TimeSpan? TotalWork {  get; set; }
        public DateTime Date { get; set; }
    }
}
