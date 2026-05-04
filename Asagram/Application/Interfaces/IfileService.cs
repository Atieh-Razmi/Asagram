using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IfileService
    {
        Task<(Guid Id, string Name)> UploadFile(string Name, string ContentType, byte[] Data, FileType fileType);
    }
}
