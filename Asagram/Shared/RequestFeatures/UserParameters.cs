using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.RequestFeatures
{
    public class UserParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }
        public string? Role {  get; set; }
        public bool? Status { get; set; }
    }
}
