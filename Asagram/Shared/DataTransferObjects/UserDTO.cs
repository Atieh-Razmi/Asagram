using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    //public record UserDTO(Guid Id,string FullName, string UserName, string PhoneNumber, string NationalCode,
    //    string RoleName, DateTime StartTime,string IP, bool Status);

    public record UserDTO {
        public Guid Id { get; set;  }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string RoleName { get; set; }
        public DateTime StartTime { get; set; }
         public string IP { get; set; } 
         public bool Status { get; set; }
    }


}
