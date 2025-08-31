using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyTracker.Infrastructure.Persistence;
using EnergyTracker.Infrastructure.Exporters;
using Microsoft.EntityFrameworkCore;

namespace EnergyTracker.Application.Queries.Exporter
{
    public class ExportUsersHandler : IRequestHandler<ExportUsers, byte[]>
    {
        private readonly EnergyTrackerDbContext _dbContext;
        private readonly IExcelExporter _excelExporter;

        public ExportUsersHandler(EnergyTrackerDbContext dbContext, IExcelExporter excelExporter)
        {
            _dbContext = dbContext;
            _excelExporter = excelExporter;
        }
        public async Task<byte[]> Handle(ExportUsers request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.ToListAsync(cancellationToken);
            return _excelExporter.ExportUsersToExcel(users);
        }
    }
}


