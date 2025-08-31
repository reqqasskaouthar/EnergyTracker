using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Consumption
{
    public class GetConsumptionById : IRequest<EnergyTracker.Domain.Entities.Consumption?>
    {
        public Guid ConsumptionId { get; set; }
        public GetConsumptionById(Guid id)
        {
            ConsumptionId = id;
        }
    }
  
}
