using EnergyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Infrastructure.Exporters
{
    public interface IExcelExporterConsumption
    {
        byte[] ExportConsumptionsToExcel(List<Consumption> consumptions);
    }
}
