using EnergyTracker.Application.Commands.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnergyTracker.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
           .NotEmpty().WithMessage("First name is required.")
           .Length(1, 30).WithMessage("First name must be between 1 and 30 characters.");

            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(1, 30).WithMessage("Last name must be between 1 and 30 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.")
                .Length(1, 50).WithMessage("Email must be between 1 and 50 characters.");
        }
    }
}
