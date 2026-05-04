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
    public class GetCitiesHandler : IRequestHandler<GetCitiesQuery, PagedList<CityDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetCitiesHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<PagedList<CityDTO>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {

            var query = _repository.Cities.Include(c=>c.Province);
            var count = await query.CountAsync(cancellationToken);
            var cities = await query.Skip((request.cityParameters.PageNumber - 1) * request.cityParameters.PageSize)
                .Take(request.cityParameters.PageSize)
                .ToListAsync(cancellationToken);
            
            var citiesDTO = _mapper.Map<List<CityDTO>>(cities);
            return new PagedList<CityDTO>(citiesDTO, count, request.cityParameters.PageNumber, request.cityParameters.PageSize);

        }
    }
}
