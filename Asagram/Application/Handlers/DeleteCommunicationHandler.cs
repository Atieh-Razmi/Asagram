using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteCommunicationHandler : IRequestHandler<DeleteCommnicationCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteCommunicationHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteCommnicationCommand request, CancellationToken cancellationToken)
        {
            var communication = await _repository.AppFiles.FirstOrDefaultAsync(e => e.Id == request.id);
            if (communication == null)
                throw new FileNotFoundException();

            _repository.AppFiles.Remove(communication);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
