using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Role>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;

        public CreateRoleHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Role>(request.role);
            _repository.Roles.Add(role);
            await _repository.SaveChangesAsync(cancellationToken);
            return role;
        }
    }
}
