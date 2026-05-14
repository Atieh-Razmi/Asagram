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
        private readonly ICurrentUserService _currentUserService;
        public LogoutUserHandler(IRepositoryContext repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var user = await _repository.Users.FirstOrDefaultAsync(e => e.Id == userId);
            if (user == null)
                throw new UserNotFoundException();
            var workLog = await _repository.WorkLogs.FirstOrDefaultAsync(c => c.UserId == userId && c.Date == DateTime.Today);
            if (workLog == null)
                throw new Exception("User has not checked in today");


            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = default;
            workLog.EndTime = DateTime.Now;
            user.Status = false;
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
