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
    public class GetOverTimeUserHandler : IRequestHandler<GetOverTimesUserQuery, PagedList<UserOverTimeResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        private readonly ICurrentUserService _currentUserService;
        public GetOverTimeUserHandler(IMapper mapper, IRepositoryContext repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<PagedList<UserOverTimeResponseDTO>> Handle(GetOverTimesUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var query = _repository.OverTimes.Where(c => c.UserId == userId).Include(c=>c.Project).AsNoTracking();
            //.FilterUserOverTimes(request.userOverTimeParameters);
            var count = await query.CountAsync();
            var overtimes = await query.Skip((request.userOverTimeParameters.PageNumber - 1) * request.userOverTimeParameters.PageSize)
                .Take(request.userOverTimeParameters.PageSize)
                .ToListAsync(cancellationToken);
            var overtimesDTOs = _mapper.Map<IEnumerable<UserOverTimeResponseDTO>>(overtimes);
            return new PagedList<UserOverTimeResponseDTO>(
                overtimesDTOs.ToList(), count, request.userOverTimeParameters.PageNumber, request.userOverTimeParameters.PageSize);
        }
    }
}
