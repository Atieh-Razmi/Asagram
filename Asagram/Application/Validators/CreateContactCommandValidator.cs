using Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public sealed class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(c => c.ContactForCreateDTO.FirstName).NotEmpty()
                .WithMessage("نام الزامی است.").MaximumLength(60);

            RuleFor(c => c.ContactForCreateDTO.LastName).NotEmpty()
                .WithMessage("نام خانوادگی الزامی است.").MaximumLength(60);

            RuleFor(c => c.ContactForCreateDTO.Phones).NotEmpty()
                .WithMessage("حداقل یه شماره لازم است.");

            RuleForEach(c => c.ContactForCreateDTO.Phones)
                .Matches(@"^09\d{9}$")
                .WithMessage("فرمت موبایل اشتباه است.");

            RuleFor(c => c.ContactForCreateDTO.Email)
                .EmailAddress()
                .WithMessage("format email");




        }
    }
}
