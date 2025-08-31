using EnergyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync();
        Task AddAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task<Subscription?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
