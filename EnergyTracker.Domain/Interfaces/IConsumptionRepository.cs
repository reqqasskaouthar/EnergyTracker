using EnergyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Interfaces
{
    public interface IConsumptionRepository
    {
        Task<IEnumerable<Consumption>> GetConsumptionsAsync();
        Task AddAsync(Consumption consumption);
        Task UpdateAsync(Consumption Consumption);
        Task<Consumption?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
