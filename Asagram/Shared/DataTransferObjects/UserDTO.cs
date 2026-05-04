using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserDTO(string FullName, string UserName, string PhoneNumber, string NationalCode,
        string RoleName, DateTime StartTime,string IP, bool Status);
    
}
