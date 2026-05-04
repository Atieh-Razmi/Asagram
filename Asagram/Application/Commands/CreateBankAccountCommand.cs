using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record CreateBankAccountCommand(BankAccountForCreateDTO bankAccountDTO) : IRequest<Unit>;
    
}
