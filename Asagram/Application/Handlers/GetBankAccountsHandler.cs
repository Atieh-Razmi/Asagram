using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetBankAccountsHandler : IRequestHandler<GetBankAccountsQuery, IEnumerable<BankAccountDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetBankAccountsHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<BankAccountDTO>> Handle(GetBankAccountsQuery request, CancellationToken cancellationToken)
        {
            var banks = await _repository.BankAccounts.ToListAsync(cancellationToken);
            var banksDTO = _mapper.Map<IEnumerable<BankAccountDTO>>(banks);
            return banksDTO;

            
        }
    }
}
