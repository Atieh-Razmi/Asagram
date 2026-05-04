using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record CreateContactCommand(ContactForCreateDTO ContactForCreateDTO) : IRequest<Contact>;
    
}
