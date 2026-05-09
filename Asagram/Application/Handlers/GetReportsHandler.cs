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
    public class GetReportsHandler : IRequestHandler<GetReportsQuery, PagedList<ReportDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetReportsHandler(IMapper mapper, IRepositoryContext repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<ReportDTO>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Reports.AsNoTracking();
            //FilterReport(request.reportParameters);
            var count = await query.CountAsync();
            var reports = await query.Skip((request.reportParameters.PageNumber - 1) * request.reportParameters.PageSize)
                .Take(request.reportParameters.PageSize)
                .ToListAsync(cancellationToken);
            var reportDTOs = _mapper.Map<IEnumerable<ReportDTO>>(reports);
            return new PagedList<ReportDTO>(reportDTOs.ToList(),
                count, request.reportParameters.PageNumber, request.reportParameters.PageSize);


        }
    }
}
