using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ReportDTO
    {
        public string FullName {  get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }
    }
}
