using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authService;
        public RegisterUserHandler(IMapper mapper, IAuthenticationService authService)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerUserDTO = await _authService.RegisterUser(request.user);
            if (registerUserDTO == null)
                throw new UserNotFoundException();
            var user = _mapper.Map<User>(registerUserDTO);
            return user;
        }
    }
}
