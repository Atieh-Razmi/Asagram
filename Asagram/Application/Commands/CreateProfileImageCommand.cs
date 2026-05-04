using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record CreateProfileImageCommand(Guid id, UploadFileDTO uploadImage) : IRequest<Unit>;
    
}
