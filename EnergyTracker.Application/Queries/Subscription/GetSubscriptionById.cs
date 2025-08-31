using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Subscription
{
    public class GetSubscriptionById : IRequest<EnergyTracker.Domain.Entities.Subscription?>
    {
        public Guid SubscriptionId { get; set; }
        public GetSubscriptionById(Guid id)
        {
            SubscriptionId = id;
        }
    }
}
