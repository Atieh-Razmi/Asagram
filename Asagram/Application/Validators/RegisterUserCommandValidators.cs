using Application.Commands;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Validators
{
    public sealed class RegisterUserCommandValidators : AbstractValidator<UserForRegistrationDTO>
    {
        public RegisterUserCommandValidators()
        {
            RuleFor(c => c.UserName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.Password).NotEmpty().MaximumLength(50);
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.ConfirmPassword).NotEmpty().MaximumLength(50);
            

        }
    }
}
