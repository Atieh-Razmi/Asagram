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
    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDTO>>
    {

        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetProjectsHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<ProjectDTO>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.Projects.ToListAsync(cancellationToken);
            var projectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return projectsDTO;
        }
    }
}
