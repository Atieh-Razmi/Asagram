using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using Entities.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetBankAccountHandler : IRequestHandler<GetBankAccountQuery, BankAccountForCreateDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public GetBankAccountHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BankAccountForCreateDTO> Handle(GetBankAccountQuery request, CancellationToken cancellationToken)
        {
            var bank = await _repository.BankAccounts.FirstOrDefaultAsync(e => e.Id == request.id);
            if (bank == null)
                throw new BankNotFoundExeception();
            return _mapper.Map<BankAccountForCreateDTO>(bank);

        }
    }
}

