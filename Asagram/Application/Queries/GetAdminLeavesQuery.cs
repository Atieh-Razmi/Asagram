using MediatR;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetAdminLeavesQuery(AdminLeaveParameters adminLeaveParameters) : IRequest<PagedList<AdminLeaveResponseDTO>>;
    
}
