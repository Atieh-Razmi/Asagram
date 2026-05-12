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
        private readonly ICurrentUserService _currentUserService;
        public UpdateLeaveStatusHandler(IRepositoryContext repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(UpdateLeaveStatusCommand request, CancellationToken cancellationToken)
        {

            var leave = await _repository.Leaves.FirstOrDefaultAsync(c => c.Id == request.id);

            var leavesteps = _repository.LeaveSteps.FirstOrDefault(c => c.LeaveId == leave.Id);
            var user = _currentUserService.UserId;
            var leaveStep  = await _repository.LeaveSteps.FirstOrDefaultAsync(c => c.ApproverId == user);
            if(leaveStep != null)
            {
                leaveStep.LeaveStepStatus = request.status.Status;
            }
            else
            {
                throw new Exception("you didnt have permision to set status for leave.");
            }
            
            
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
