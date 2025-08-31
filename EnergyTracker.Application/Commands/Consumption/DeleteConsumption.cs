using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Consumption
{
    public class DeleteConsumption : IRequest<Unit>
    {
        public Guid consumptionId { get; }

        public DeleteConsumption(Guid consumptionId)
        {
            this.consumptionId = consumptionId;
        }
    }
}
