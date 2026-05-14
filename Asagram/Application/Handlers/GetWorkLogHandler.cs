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


using Repository.Extensions;

namespace Application.Handlers
{
    public class GetWorkLogHandler : IRequestHandler<GetWorkLogsQuery, PagedList<WorkLogDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public GetWorkLogHandler(IRepositoryContext repository, ICurrentUserService currentUserService
            , IMapper mapper)
        {
            _repository = repository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<PagedList<WorkLogDTO>> Handle(GetWorkLogsQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var query = _repository.WorkLogs.Include(c=>c.User).AsNoTracking();
            query = query.FilterWorkLog(request.workLogParameters).Search(request.workLogParameters);
            var count = await query.CountAsync();
            var worklogs = await query
                .Skip((request.workLogParameters.PageNumber - 1) * request.workLogParameters.PageSize)
                .Take(request.workLogParameters.PageSize)
                .ToListAsync(cancellationToken);
            var workLogDTOs = _mapper.Map<IEnumerable<WorkLogDTO>>(worklogs);
            return new PagedList<WorkLogDTO>(
                workLogDTOs.ToList(), count, request.workLogParameters.PageNumber, request.workLogParameters.PageSize);
        }
    }
}
