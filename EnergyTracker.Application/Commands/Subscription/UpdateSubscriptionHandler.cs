using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Subscription
{
    public class UpdateSubscriptionHandler : IRequestHandler<Updatesubscription, Unit>
    {
        private readonly ISubscriptionRepository _repository;

        public UpdateSubscriptionHandler(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(Updatesubscription request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.SubscriptionId);
            if (existing == null)
                throw new Exception("Subscription not found");

            existing.UserId = request.UserId;
            existing.PlanName = request.PlanName;
            existing.StartDate = request.StartDate;
            existing.EndDate = request.EndDate;

            await _repository.UpdateAsync(existing);

            return Unit.Value;
        }
    }
}


