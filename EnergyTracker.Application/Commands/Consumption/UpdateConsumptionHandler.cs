using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Consumption
{
    public class UpdateConsumptionHandler : IRequestHandler<UpdateConsumptionCommand, Unit>
    {
        private readonly IConsumptionRepository _repository;

        public UpdateConsumptionHandler(IConsumptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateConsumptionCommand request, CancellationToken cancellationToken)
        {
            var consumption = await _repository.GetByIdAsync(request.ConsumptionId);
            if (consumption == null)
            {
                throw new KeyNotFoundException($"Consumption with Id {request.ConsumptionId} not found.");
            }

            consumption.UserId = request.UserId;
            consumption.Date = request.Date;
            consumption.EnergyType = request.EnergyType;
            consumption.Quantity = request.Quantity;
            consumption.Unit = request.Unit;

            await _repository.UpdateAsync(consumption);

            return Unit.Value;
        }
    }

}
