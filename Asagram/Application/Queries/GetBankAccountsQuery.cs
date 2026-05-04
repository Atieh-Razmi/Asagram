using MediatR;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetBankAccountsQuery(BankAccountParameters bankAccountParameters) : IRequest<IEnumerable<BankAccountDTO>>;
    
}
