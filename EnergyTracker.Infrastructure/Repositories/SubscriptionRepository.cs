using EnergyTracker.Domain.Entities;
using EnergyTracker.Domain.Interfaces;
using EnergyTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly EnergyTrackerDbContext _context;
        public SubscriptionRepository(EnergyTrackerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Subscription?> GetByIdAsync(Guid id)
        {
            return await _context.Subscriptions
                                .Include(c => c.User)
                                .FirstOrDefaultAsync(c => c.SubscriptionId == id);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync()
        {
            return await _context.Subscriptions
                         .Include(c => c.User)
                         .ToListAsync();
        }

        public async Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }
    }
}
