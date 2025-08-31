using EnergyTracker.Application.Commands.User;
using EnergyTracker.Application.Common.Exceptions;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Consumption
{
    public class DeleteConsumptionHandler : IRequestHandler<DeleteConsumption, Unit>
    {
        private readonly IConsumptionRepository _consumptionRepository;

        public DeleteConsumptionHandler(IConsumptionRepository consumptionRepositor)
        {
            this._consumptionRepository = consumptionRepositor;
        }

        public async Task<Unit> Handle(DeleteConsumption request, CancellationToken cancellationToken)
        {
            var consumption = await _consumptionRepository.GetByIdAsync(request.consumptionId);
            if (consumption == null)
            {
                throw new NotFoundException("consumption not found");
            }

            await  _consumptionRepository.DeleteAsync(request.consumptionId);
            return Unit.Value;
        }
    }
}
