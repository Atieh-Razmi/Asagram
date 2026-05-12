using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateBankAccountHandler : IRequestHandler<CreateBankAccountCommand, MediatR.Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;

        public CreateBankAccountHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MediatR.Unit> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var findbank = await _repository.BankAccounts.FirstOrDefaultAsync(
                e => e.Title == request.bankAccountDTO.Title);
            //if( findbank != null )
            //throw
            var bank = _mapper.Map<BankAccount>(request.bankAccountDTO);
            _repository.BankAccounts.Add(bank);
            await _repository.SaveChangesAsync(cancellationToken);
            
            return MediatR.Unit.Value;
        }
    }
}
