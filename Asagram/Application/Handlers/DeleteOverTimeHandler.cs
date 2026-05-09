using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteOverTimeHandler : IRequestHandler<DeleteOverTimeCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteOverTimeHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteOverTimeCommand request, CancellationToken cancellationToken)
        {
            var overTime = await _repository.OverTimes.FirstOrDefaultAsync(c => c.Id == request.id);
            if (overTime == null)
                throw new Exception("این اضافه کاری وجود ندارد.");

            _repository.OverTimes.Remove(overTime);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
