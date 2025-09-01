using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Application.Queries.Exporter
{
    public record ExportUserConsumptionsToPdf(Guid UserId) : IRequest<byte[]>;

}
