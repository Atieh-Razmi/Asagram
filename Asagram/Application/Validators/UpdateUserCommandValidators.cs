using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Validators
{
    public sealed class UpdateUserCommandValidators : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidators()
        {
            RuleFor(c => c.UserForUpdate.UserName).NotEmpty().MaximumLength(50);
            
            RuleFor(c => c.UserForUpdate.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(c => c.UserForUpdate.LastName).NotEmpty().MaximumLength(50);
            
            RuleFor(c => c.UserForUpdate.UserUnit).NotEmpty().MaximumLength(50);
            RuleFor(c => c.UserForUpdate.RoleName).NotEmpty();
        }
    }
}
