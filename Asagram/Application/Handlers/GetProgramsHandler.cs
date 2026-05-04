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
    public class GetProgramsHandler : IRequestHandler<GetProgramsQuery, IEnumerable<ProgramResponseDTO>>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetProgramsHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProgramResponseDTO>> Handle(GetProgramsQuery request, CancellationToken cancellationToken)
        {
            var programs = await _repository.Programs.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ProgramResponseDTO>>(programs);
        }
    }
}
