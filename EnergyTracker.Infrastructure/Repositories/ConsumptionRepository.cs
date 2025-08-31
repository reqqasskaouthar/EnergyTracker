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
    public class ConsumptionRepository : IConsumptionRepository
    {
        private readonly EnergyTrackerDbContext _context;
        public ConsumptionRepository(EnergyTrackerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Consumption consumption)
        {
            await _context.Consumptions.AddAsync(consumption);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var consuption = await _context.Consumptions.FindAsync(id);
            if (consuption != null)
            {
                _context.Consumptions.Remove(consuption);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Consumption>> GetConsumptionsAsync()
        {
            return await _context.Consumptions
                         .Include(c => c.User)  
                         .ToListAsync();
        }

        public async Task UpdateAsync(Consumption consumption)
        {
            _context.Consumptions.Update(consumption);
            await _context.SaveChangesAsync();
        }
        public async Task<Consumption?> GetByIdAsync(Guid id)
        {
            return await _context.Consumptions
                                 .Include(c => c.User)              
                                 .FirstOrDefaultAsync(c => c.ConsumptionId == id);
        }
    }
}
