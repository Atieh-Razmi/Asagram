using MediatR;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Application.Commands
{
    public record DeleteContactCommand(Guid id) : IRequest<Unit>;
    
}
