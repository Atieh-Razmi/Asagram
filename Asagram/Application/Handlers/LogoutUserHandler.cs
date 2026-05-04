using Application.Commands;
using Application.Interfaces;
using Entities.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class LogoutUserHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly IRepositoryContext _repository;
        public LogoutUserHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(e => e.Id == request.Id);
            if (user == null)
                throw new UserNotFoundException();


            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = default;
            user.EndTime = DateTime.Now;
            user.Status = false;
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
