using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Subscription
{
    public class DeleteSubscription : IRequest<Unit>
    {
        public Guid subscriptionId { get; }

        public DeleteSubscription(Guid subscriptionId)
        {
            this.subscriptionId = subscriptionId;
        }
    }
}
