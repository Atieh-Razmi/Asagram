using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;


namespace Shared.DataTransferObjects
{
    public record UploadFileDTO
    {
        public IFormFile File { get; set; } = null!;
    }
}
