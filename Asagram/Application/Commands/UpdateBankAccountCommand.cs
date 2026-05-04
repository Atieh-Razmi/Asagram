using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record UpdateBankAccountCommand(Guid id, BankAccountForCreateDTO bankAccount) : IRequest<Unit>;
    
}
