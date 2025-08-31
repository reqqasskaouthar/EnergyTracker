using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Consumption
{
    public class GetAllConsumptionsHandler : IRequestHandler<GetAllConsumptions, IEnumerable<EnergyTracker.Domain.Entities.Consumption>>
    {
        private readonly IConsumptionRepository _repository;

        public GetAllConsumptionsHandler(IConsumptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EnergyTracker.Domain.Entities.Consumption>> Handle(GetAllConsumptions request, CancellationToken cancellationToken)
        {
            return await _repository.GetConsumptionsAsync();
        }
    }
}
