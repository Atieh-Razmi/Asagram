using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetUnitsQuery() : IRequest<IEnumerable<Entities.Models.Unit>>;
    
}
