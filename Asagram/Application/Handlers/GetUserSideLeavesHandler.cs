using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetUserSideLeavesHandler : IRequestHandler<GetUserSideLeavesQuery, PagedList<UserLeaveResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetUserSideLeavesHandler(IMapper mapper, IRepositoryContext repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<UserLeaveResponseDTO>> Handle(GetUserSideLeavesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Leaves.Where(c => c.UserId == request.id).AsNoTracking();
            //.FilterUserLeaves(request.userLeaveParameters);
            var count = await query.CountAsync();
            var leaves = await query.Skip((request.userLeaveParameters.PageNumber - 1) * request.userLeaveParameters.PageSize)
                .Take(request.userLeaveParameters.PageSize)
                .ToListAsync(cancellationToken);
            var leaveDTOs = _mapper.Map<IEnumerable<UserLeaveResponseDTO>>(leaves);
            return new PagedList<UserLeaveResponseDTO>(leaveDTOs.ToList(), count, request.userLeaveParameters.PageNumber, request.userLeaveParameters.PageSize);

        }
    }
}
