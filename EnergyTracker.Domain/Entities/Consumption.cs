using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Domain.Entities
{
    public class Consumption
    {
        public Guid ConsumptionId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string EnergyType { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public User User { get; set; }

        // Constructeur sans paramètre requis par EF Core
        public Consumption()
        {
            ConsumptionId = Guid.NewGuid();
            Date = DateTime.UtcNow;
        }

        // Constructeur paramétré pour usage métier (optionnel)
        public Consumption(Guid userId, string energyType, decimal quantity, string unit, DateTime date)
        {
            ConsumptionId = Guid.NewGuid();
            UserId = userId;
            EnergyType = energyType;
            Quantity = quantity;
            Unit = unit;
            Date = date;
        }

    }
}
