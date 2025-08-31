using EnergyTracker.Application.Commands.Consumption;
using EnergyTracker.Application.Commands.User;
using EnergyTracker.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Validators
{
    public class CreateConsumptionValidator : AbstractValidator<Createconsumption>
    {
        public CreateConsumptionValidator() 
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.EnergyType)
                .NotEmpty().WithMessage("Energy type is required.")
                .Length(1, 50).WithMessage("Energy type must be between 1 and 50 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Unit)
                .NotEmpty().WithMessage("Unit is required.")
                .Length(1, 10).WithMessage("Unit must be between 1 and 10 characters.");

            RuleFor(x => x.Date)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");
        }
    }

}
