using EnergyTracker.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Infrastructure.Persistence
{
    public class EnergyTrackerDbContext : DbContext
    {
    
        public EnergyTrackerDbContext(DbContextOptions<EnergyTrackerDbContext> options, IMediator mediator)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumption>()
                .Property(c => c.Quantity)
                .HasPrecision(18, 2);
        }
        public DbSet<User>Users { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        
    }
}



