using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.RequestFeatures
{
    public class WorkLogParameters : RequestParameters
    {
        public Guid? user {  get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
