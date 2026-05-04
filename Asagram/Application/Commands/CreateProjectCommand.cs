using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record CreateProjectCommand(ProjectDTO project) : IRequest<Project>;
    
}
