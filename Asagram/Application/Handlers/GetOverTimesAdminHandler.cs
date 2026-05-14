using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetOverTimesAdminHandler : IRequestHandler<GetOverTimesAdminQuery, PagedList<AdminOverTimeResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetOverTimesAdminHandler(IMapper mapper, IRepositoryContext repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<AdminOverTimeResponseDTO>> Handle(GetOverTimesAdminQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.OverTimes.Include(c => c.User).Where(c => c.OverTimeStatus == OverTimeStatus.Checking).AsNoTracking();
            
            var count = await query.CountAsync();
            var overtimes = await query.Skip((request.adminOverTimeParameters.PageNumber - 1) * request.adminOverTimeParameters.PageSize)
                .Take(request.adminOverTimeParameters.PageSize)
                .ToListAsync(cancellationToken);
            var overTimeDTOs = _mapper.Map<IEnumerable<AdminOverTimeResponseDTO>>(overtimes);
            return new PagedList<AdminOverTimeResponseDTO>(overTimeDTOs.ToList(), count, request.adminOverTimeParameters.PageNumber, request.adminOverTimeParameters.PageSize);

        }
    }
}
