using Application.Commands;
using Application.Interfaces;
using Entities.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteBankAccountHandler : IRequestHandler<DeleteBankAccountCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteBankAccountHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bank = await _repository.BankAccounts.FirstOrDefaultAsync(e => e.Id == request.id);
            if (bank == null)
                throw new BankNotFoundExeception();

            _repository.BankAccounts.Remove(bank);
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
