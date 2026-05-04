using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record DeleteCustomerCommand(Guid id) : IRequest<Unit>;
    
}
