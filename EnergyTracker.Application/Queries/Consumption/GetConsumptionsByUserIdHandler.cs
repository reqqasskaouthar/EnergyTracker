using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Consumption
{
    public class GetConsumptionsByUserIdHandler : IRequestHandler<GetConsumptionsByUserId, IEnumerable<EnergyTracker.Domain.Entities.Consumption>>
    {
        private readonly IConsumptionRepository _consumptionRepository;

        public GetConsumptionsByUserIdHandler(IConsumptionRepository consumptionRepository)
        {
            _consumptionRepository = consumptionRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Consumption>> Handle(GetConsumptionsByUserId request, CancellationToken cancellationToken)
        {
            return await _consumptionRepository.GetByUserIdAsync(request.UserId);
        }
    }
}
