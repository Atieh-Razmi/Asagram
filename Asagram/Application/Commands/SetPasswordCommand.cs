using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record SetPasswordCommand(Guid UserId,PasswordDTO PasswordDTO) : IRequest<UserPasswordDTO>;
    
}
