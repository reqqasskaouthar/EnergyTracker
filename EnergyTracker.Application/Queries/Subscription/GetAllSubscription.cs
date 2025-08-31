using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Subscription
{
    public class GetAllSubscription : IRequest<IEnumerable<EnergyTracker.Domain.Entities.Subscription>>
    {
    }
}
