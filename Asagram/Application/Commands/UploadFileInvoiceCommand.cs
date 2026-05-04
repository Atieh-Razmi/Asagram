using Entities.Enums;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UploadFileInvoiceCommand(string Name, string ContentType, byte[] Data, FileType FileType) : IRequest<UploadFileResponseDTO>;
    
}
