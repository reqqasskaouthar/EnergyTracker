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
    public class GetSubscriptionByIdHandler : IRequestHandler<GetSubscriptionById, EnergyTracker.Domain.Entities.Subscription?>
    {
        private readonly ISubscriptionRepository _repository;

        public GetSubscriptionByIdHandler(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<EnergyTracker.Domain.Entities.Subscription?> Handle(GetSubscriptionById request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.SubscriptionId);
        }
    }
}
