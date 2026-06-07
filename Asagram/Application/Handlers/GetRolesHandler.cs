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
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<RoleResponseDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetRolesHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleResponseDTO>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repository.Roles.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<RoleResponseDTO>>(roles);
        }
    }
}
