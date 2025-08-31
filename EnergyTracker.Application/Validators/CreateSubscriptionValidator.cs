using EnergyTracker.Application.Commands.Consumption;
using EnergyTracker.Application.Commands.Subscription;
using EnergyTracker.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Validators
{
    public class CreateSubscriptionValidator : AbstractValidator<CreateSubscription>
    {
        public CreateSubscriptionValidator()
        {

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(x => x.PlanName)
                .NotEmpty().WithMessage("Plan name is required.")
                .Length(1, 100).WithMessage("Plan name must be between 1 and 100 characters.");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Start date cannot be in the future.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate).When(x => x.EndDate.HasValue)
                .WithMessage("End date must be after start date.")
                .When(x => x.EndDate.HasValue); 

     
        }
    }
}

