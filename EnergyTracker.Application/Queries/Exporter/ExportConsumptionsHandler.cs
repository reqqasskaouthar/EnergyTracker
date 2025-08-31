using EnergyTracker.Application.Queries.Exporter;
using EnergyTracker.Infrastructure.Exporters;
using EnergyTracker.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Exporter
{
    public class ExportConsumptionsHandler : IRequestHandler<ExportConsumptions, byte[]>
    {
        private readonly EnergyTrackerDbContext _dbContext;
        private readonly IExcelExporterConsumption _excelExporter;
        public ExportConsumptionsHandler(EnergyTrackerDbContext dbContext, IExcelExporterConsumption excelExporter)
        {
            _dbContext = dbContext;
            _excelExporter = excelExporter;
        }
        public async Task<byte[]> Handle(ExportConsumptions request, CancellationToken cancellationToken)
        {
            var consumptions = await _dbContext.Consumptions
            .Include(c => c.User)   
            .ToListAsync(cancellationToken);
            return _excelExporter.ExportConsumptionsToExcel(consumptions);
        }
    }
}