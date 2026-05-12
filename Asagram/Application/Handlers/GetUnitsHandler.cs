using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetUnitsHandler : IRequestHandler<GetUnitsQuery, IEnumerable<Entities.Models.Unit>>
    {

        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetUnitsHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Entities.Models.Unit>> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
        {
            //var units = await _repository.Units.ToListAsync(cancellationToken);

            //return _mapper.Map<IEnumerable<Entities.Models.Unit>>(units);

            return await _repository.Units.ToListAsync(cancellationToken);
        }
    }
}
