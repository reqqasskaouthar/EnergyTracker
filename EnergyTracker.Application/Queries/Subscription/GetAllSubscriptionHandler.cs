using EnergyTracker.Application.Queries.Consumption;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Subscription
{
    public class GetAllSubscriptionHandler : IRequestHandler<GetAllSubscription, IEnumerable<EnergyTracker.Domain.Entities.Subscription>>
    {
        private readonly ISubscriptionRepository _repository;

        public GetAllSubscriptionHandler(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EnergyTracker.Domain.Entities.Subscription>> Handle(GetAllSubscription request, CancellationToken cancellationToken)
        {
            return await _repository.GetSubscriptionsAsync();
        }
    }
}
