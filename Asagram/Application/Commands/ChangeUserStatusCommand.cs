using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record ChangeUserStatusCommand(Guid userId, IsActiveDTO IsActive) : IRequest<Unit>;
    
}
