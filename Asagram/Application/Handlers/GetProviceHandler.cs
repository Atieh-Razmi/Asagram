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
    public class GetProviceHandler:IRequestHandler<GetProvincesQuery, PagedList<ProvinceDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetProviceHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<PagedList<ProvinceDTO>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Provinces;
            var count =await query.CountAsync(cancellationToken);
            var provinces = await query.Skip((request.provincesParameters.PageNumber - 1) * request.provincesParameters.PageSize)
                .Take(request.provincesParameters.PageSize)
                .ToListAsync(cancellationToken);

            var provinceDTOs = _mapper.Map<List<ProvinceDTO>>(provinces);
            return new PagedList<ProvinceDTO>(provinceDTOs, count, request.provincesParameters.PageNumber, request.provincesParameters.PageSize);

        }
    }
}
