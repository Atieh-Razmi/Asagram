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
            if (userId == null)
                throw new Exception("please login first.");

            var exitWorkLog = await _repository.WorkLogs.FirstOrDefaultAsync(c=>c.UserId == userId && c.Date == DateTime.Today);
            if (exitWorkLog != null)
                throw new Exception("you already have checkIn.");

            var worklog = new Entities.Models.WorkLog
            {
                UserId = userId,
                StartTime = DateTime.Now,
                Date = DateTime.Today
            };
            

            
            _repository.WorkLogs.Add(worklog);
            
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
