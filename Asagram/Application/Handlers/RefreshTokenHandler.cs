using Application.Commands;
using Application.Interfaces;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class RefreshTokenHandler: IRequestHandler<RefreshTokenCommand, TokenDTO>
    {
        private readonly IAuthenticationService _authService;
        public RefreshTokenHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task<TokenDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RefreshToken(request.token);
        }
    }
}
