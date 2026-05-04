using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Validators
{
    public sealed class LoginCommandValidators : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidators()
        {
            RuleFor(c => c.User.UserName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.User.Password).NotEmpty().MaximumLength(50);
        }
    }
}
