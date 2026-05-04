using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UpdateUserCommand(Guid Id,UserForUpdateDTO UserForUpdate, bool TrackChanges) : IRequest<Unit>;
    
}
