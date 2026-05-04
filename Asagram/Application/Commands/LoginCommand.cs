using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public record LoginCommand(UserForAuthenticationDTO User) : IRequest<TokenDTO>;
}
