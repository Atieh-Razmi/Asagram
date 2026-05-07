using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateCheckInHandler : IRequestHandler<CreateCheckInCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly ICurrentUserService _currentUserService;
        public CreateCheckInHandler(IRepositoryContext repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(CreateCheckInCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            //var userId = Guid.Parse("2127ace2-373e-45ec-b5bf-fc81b73d2871");
            var user = await _repository.Users.FirstOrDefaultAsync(c=>c.Id == userId);
            user.StartTime = DateTime.Now;
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
