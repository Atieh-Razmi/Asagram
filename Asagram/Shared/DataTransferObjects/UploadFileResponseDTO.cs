using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public class UploadFileResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }

}
