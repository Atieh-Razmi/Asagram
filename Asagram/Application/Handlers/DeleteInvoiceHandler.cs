using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteInvoiceHandler(IRepositoryContext repository)
        {
         _repository = repository;   
        }

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _repository.AppFiles.FirstOrDefaultAsync(e => e.Id == request.id);
            if (invoice == null)
                throw new FileNotFoundException();

            _repository.AppFiles.Remove(invoice);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
