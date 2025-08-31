using EnergyTracker.Application.Commands.Consumption;
using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Subscription
{
    public class DeleteSubscriptionHandler : IRequestHandler<DeleteSubscription, Unit>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public DeleteSubscriptionHandler(ISubscriptionRepository subscriptionRepository)
        {
            this._subscriptionRepository = subscriptionRepository;
        }

        public async Task<Unit> Handle(DeleteSubscription request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.subscriptionId);
            if (subscription == null)
            {
                throw new NotFoundException("consumption not found");
            }

            await _subscriptionRepository.DeleteAsync(request.subscriptionId);
            return Unit.Value;
        }
    }
}
