using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetProgramsQuery() : IRequest<IEnumerable<ProgramResponseDTO>>;
    
}
