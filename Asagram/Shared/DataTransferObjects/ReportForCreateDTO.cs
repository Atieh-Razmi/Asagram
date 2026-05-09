using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ReportForCreateDTO
    {
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
