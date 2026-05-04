using Application.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Exceptions;
using Shared.DataTransferObjects;

namespace Application.Handlers
{
    public class ChangeUserStatusHandler : IRequestHandler<ChangeUserStatusCommand, Unit>
    {
        private readonly IUserService _service;
        private readonly IRepositoryContext _repository;
        public ChangeUserStatusHandler(IUserService service, IRepositoryContext repository)
        {
            _service = service;
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id == request.userId);
            if (user == null)
                throw new UserNotFoundException();
            user.IsActive = request.IsActive.IsActive;
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
