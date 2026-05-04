using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    //public record TokenDTO
    //{
    //    public string AccessToken { get; set; }
    //    public string RefreshToken { get; set; }
    //}
    public record TokenDTO(string AccessToken, string RefreshToken);

}
