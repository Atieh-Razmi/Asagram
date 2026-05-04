using Application.Interfaces;
using Application.Queries;
using MediatR;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Application.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, (IEnumerable<UserDTO>, MetaData metaData)>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUsersHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<(IEnumerable<UserDTO>, MetaData metaData)> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsersAsync(request.userParameters, request.TrackChanges);
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            return (usersDTO, users.MetaData);
        }
    }
}
