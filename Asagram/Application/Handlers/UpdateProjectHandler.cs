using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public UpdateProjectHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Projects.FirstOrDefaultAsync(c => c.Id == request.id);
            if (project == null)
                throw new Exception("project not found.");
            _mapper.Map(request.project ,project);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
