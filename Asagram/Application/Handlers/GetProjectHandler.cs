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
    public class GetProjectHandler : IRequestHandler<GetProjectQuery, ProjectDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetProjectHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ProjectDTO> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.Projects.FirstOrDefaultAsync(c => c.Id == request.id);
            if (project == null)
                throw new Exception("project not found.");

            return _mapper.Map<ProjectDTO>(project);
        }
    }
}
