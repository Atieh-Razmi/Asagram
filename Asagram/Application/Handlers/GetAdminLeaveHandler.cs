using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using Entities.Enums;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Handlers
{
    public class GetAdminLeaveHandler : IRequestHandler<GetAdminLeavesQuery, PagedList<AdminLeaveResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetAdminLeaveHandler(IMapper mapper, IRepositoryContext repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedList<AdminLeaveResponseDTO>> Handle(GetAdminLeavesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Leaves.Include(c=>c.User).Where(c => c.LeaveStatus == LeaveStatus.Checking).AsNoTracking();
               // .FilterAdminLeaves(request.adminLeaveParameters);
            var count = await query.CountAsync();
            var leaves = await query.Skip((request.adminLeaveParameters.PageNumber - 1) * request.adminLeaveParameters.PageSize)
                .Take(request.adminLeaveParameters.PageSize)
                .ToListAsync(cancellationToken);
            var leaveDTOs = _mapper.Map<IEnumerable<AdminLeaveResponseDTO>>(leaves);
            return new PagedList<AdminLeaveResponseDTO>(leaveDTOs.ToList(), count, request.adminLeaveParameters.PageNumber, request.adminLeaveParameters.PageSize);
        }

    }
}
