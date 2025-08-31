using EnergyTracker.Application.Commands.User;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Consumption
{
    public class CreateConsumptionHandler : IRequestHandler<Createconsumption, Guid>
    {
        private readonly IConsumptionRepository _repository;

        public CreateConsumptionHandler(IConsumptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(Createconsumption request, CancellationToken cancellationToken)
        {
            var consumption = new Domain.Entities.Consumption(
                userId: request.UserId,
                energyType: request.EnergyType,
                quantity: request.Quantity,
                unit: request.Unit,
                date: request.Date
            );

            await _repository.AddAsync(consumption);

            return consumption.ConsumptionId;
        }
    }
}
