using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Consumption
{
    public class GetAllConsumptions : IRequest<IEnumerable<EnergyTracker.Domain.Entities.Consumption>>
    {

    }
}
