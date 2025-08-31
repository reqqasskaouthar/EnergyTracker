using EnergyTracker.Application.Commands.Consumption;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Subscription
{
    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscription, Guid>
    {
        private readonly ISubscriptionRepository _repository;

       public CreateSubscriptionHandler(ISubscriptionRepository repository)
       {
            _repository = repository;
       }

       public async Task<Guid> Handle(CreateSubscription request, CancellationToken cancellationToken)
       {
            var subscription = new Domain.Entities.Subscription
            {
                 UserId = request.UserId,
                 PlanName = request.PlanName,
                 StartDate = request.StartDate,
                 EndDate = request.EndDate
            };

            await _repository.AddAsync(subscription);

             return subscription.SubscriptionId;
       }

    }
}
