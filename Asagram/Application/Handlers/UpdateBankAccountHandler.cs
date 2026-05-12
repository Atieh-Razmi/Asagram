using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand, MediatR.Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public UpdateBankAccountHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MediatR.Unit> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bank = await _repository.BankAccounts.FirstOrDefaultAsync(e => e.Id == request.id);
            if (bank == null)
                throw new BankNotFoundExeception();

            _mapper.Map(request.bankAccount, bank);
            await _repository.SaveChangesAsync(cancellationToken);
            return MediatR.Unit.Value;

        }
    }
}
