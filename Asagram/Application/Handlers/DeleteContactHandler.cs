using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteContactHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repository.Contacts.FirstOrDefaultAsync(v => v.Id == request.id);
            if (contact == null)
                throw new Exception("contant not found.");
            _repository.Contacts.Remove(contact);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
