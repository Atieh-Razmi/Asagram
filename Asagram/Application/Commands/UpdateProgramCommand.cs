using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UpdateProgramCommand(Guid id, ProgramForCreateDTO program) : IRequest<Unit>;
    
}
