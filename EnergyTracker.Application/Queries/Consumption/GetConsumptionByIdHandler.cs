using EnergyTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace EnergyTracker.Application.Queries.Consumption
{
    public class GetConsumptionByIdHandler : IRequestHandler<GetConsumptionById,EnergyTracker.Domain.Entities.Consumption?>
    {
        private readonly IConsumptionRepository _repository;

    public GetConsumptionByIdHandler(IConsumptionRepository repository)
    {
        _repository = repository;
    }

    public async Task<EnergyTracker.Domain.Entities.Consumption?> Handle(GetConsumptionById request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.ConsumptionId);
    }
}
}
