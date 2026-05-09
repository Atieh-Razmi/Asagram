using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record DeleteOverTimeCommand(Guid id) : IRequest<Unit>;
    
}
