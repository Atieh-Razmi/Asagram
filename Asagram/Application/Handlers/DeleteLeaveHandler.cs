using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteLeaveHandler : IRequestHandler<DeleteLeaveCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteLeaveHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteLeaveCommand request, CancellationToken cancellationToken)
        {
            var leave = await _repository.Leaves.FirstOrDefaultAsync(c => c.Id == request.id);
            if (leave == null)
                throw new Exception("مرخصی وجوئ ندارد.");

            _repository.Leaves.Remove(leave);
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
