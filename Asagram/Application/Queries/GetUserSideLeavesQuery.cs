using MediatR;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetUserSideLeavesQuery(Guid id,UserLeaveParameters userLeaveParameters) : IRequest<PagedList<UserLeaveResponseDTO>>;
    
}
