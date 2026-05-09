using Application.Commands;
using Application.Interfaces;
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
        public UpdateOverTimeStatusHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateOverTimeStatusCommand request, CancellationToken cancellationToken)
        {
            var overTime = await _repository.OverTimes.FirstOrDefaultAsync(c => c.Id == request.id);
            if (overTime == null)
                throw new Exception("این اضافه کاری وجود ندارد.");

            overTime.OverTimeStatus = request.overTimeStatusDTO.OverTimeStatus;
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
