using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public CreateProjectHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var newProject = await _repository.Projects.FirstOrDefaultAsync(c => c.Title == request.project.Title);
            if (newProject != null)
                throw new Exception("project is exist.");
            var project = _mapper.Map<Project>(request.project);
            _repository.Projects.Add(project);
            await _repository.SaveChangesAsync(cancellationToken);
            return project;

        }
    }
}
