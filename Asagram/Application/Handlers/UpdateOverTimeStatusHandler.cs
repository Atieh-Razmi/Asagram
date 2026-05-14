using Application.Commands;
using Application.Interfaces;
using Entities.Enums;

//using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateOverTimeStatusHandler : IRequestHandler<UpdateOverTimeStatusCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateOverTimeStatusHandler(IRepositoryContext repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(UpdateOverTimeStatusCommand request, CancellationToken cancellationToken)
        {
            var overTime = await _repository.OverTimes.Include(c=>c.OverTimeSteps).FirstOrDefaultAsync(c => c.Id == request.id);
            if (overTime == null)
                throw new Exception("این اضافه کاری وجود ندارد.");

            var user = _currentUserService.UserId;
            var overTimeStep = await _repository.OverTimeSteps.FirstOrDefaultAsync(
                c => c.OverTimeId == overTime.Id && c.ApproverId == user);

            if (overTimeStep != null)
            {
                overTimeStep.OverTimeStepStatus = request.overTimeStatusDTO.OverTimeStatus;
                
            }
            else
            {
                throw new Exception("you didnt have permision to set status for overtime.");
            }
            overTime.OverTimeStatus =
                overTime.OverTimeSteps.All(s => s.OverTimeStepStatus == OverTimeStepStatus.Confirmed)
                    ? OverTimeStatus.Confirmed
                    : overTime.OverTimeSteps.Any(s => s.OverTimeStepStatus == OverTimeStepStatus.Cancelled)
                        ? OverTimeStatus.NotConfirmed
                        : OverTimeStatus.Checking;

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
