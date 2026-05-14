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
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoQuery, UserInfoDTO>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetUserInfoHandler(ICurrentUserService currentUserService, IRepositoryContext repository, IMapper mapper)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserInfoDTO> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var user = await _repository.Users.Include(c=>c.Unit).Include(c => c.UserRoles).ThenInclude(ur => ur.Role)
                .Include(c => c.ManagedUnits).FirstOrDefaultAsync(c => c.Id == userId);
            return _mapper.Map<UserInfoDTO>(user);
        }
    }
}
