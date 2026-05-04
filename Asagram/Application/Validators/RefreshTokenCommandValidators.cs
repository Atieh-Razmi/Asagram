using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Validators
{
    public sealed class RefreshTokenCommandValidators : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidators()
        {

        }
    }
}
