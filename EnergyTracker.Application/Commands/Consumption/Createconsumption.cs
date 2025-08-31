using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Commands.Consumption
{
    public class Createconsumption : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string EnergyType { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}
