using Application.Commands;
using Application.Interfaces;
using Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateLeaveStatusHandler : IRequestHandler<UpdateLeaveStatusCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public UpdateLeaveStatusHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateLeaveStatusCommand request, CancellationToken cancellationToken)
        {
            var leave = await _repository.Leaves.FirstOrDefaultAsync(c => c.Id == request.id);
            leave.LeaveStatus = request.status.Status;
            leave.UpdatedAt = DateTime.Now;
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
