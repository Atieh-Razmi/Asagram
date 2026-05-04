using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.Commands;
using Shared.DataTransferObjects;
using Entities.Exceptions;

namespace Application.Handlers
{
    public class LoginHandler: IRequestHandler<LoginCommand, TokenDTO>
    {
        private readonly IAuthenticationService _authService;
        private readonly IRepositoryContext _repository;
        public LoginHandler(IAuthenticationService authService, IRepositoryContext repository)
        {
            _authService = authService;
            _repository = repository;
        }
        public async Task<TokenDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authService.ValidateUser(request.User);
            if (user == null)
                throw new UserNotFoundException();
            var token = await _authService.CreateToken(populateExp: true);

            user.Status = true;
            _repository.Users.Update(user);
            await _repository.SaveChangesAsync(cancellationToken);
            return token;

        }
    }
}
