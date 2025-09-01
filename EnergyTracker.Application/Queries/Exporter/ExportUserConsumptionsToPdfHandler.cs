using EnergyTracker.Application.Queries.Exporter;
using EnergyTracker.Domain.Entities;
using EnergyTracker.Domain.Interfaces;
using MediatR;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EnergyTracker.Application.Queries.Exporter
{
    public class ExportUserConsumptionsToPdfHandler : IRequestHandler<ExportUserConsumptionsToPdf, byte[]>
    {
        private readonly IConsumptionRepository _repository;
        private readonly IUserRepository _userRepository;

        public ExportUserConsumptionsToPdfHandler(
            IConsumptionRepository consumptionRepository,
            IUserRepository userRepository)
        {
            _repository = consumptionRepository;
            _userRepository = userRepository;
        }

        public async Task<byte[]> Handle(ExportUserConsumptionsToPdf request, CancellationToken cancellationToken)
        {
            var consumptions = await _repository.GetByUserIdAsync(request.UserId);
            var user = await _userRepository.GetByIdAsync(request.UserId);
            string userName = user != null ? user.FirstName : "Utilisateur inconnu";
            string lastName = user != null ? user.LastName : "Utilisateur inconnu";

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(60);
                    page.Header().Text($"Consommations de {userName} {lastName}")
                        .FontSize(18).Bold().AlignCenter();
                    

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn(); 
                            columns.RelativeColumn(); 
                            columns.RelativeColumn(); 
                        });

                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).Text("Date").Bold();
                            header.Cell().Element(CellStyle).Text("Énergie").Bold();
                            header.Cell().Element(CellStyle).Text("Quantité").Bold();
                            header.Cell().Element(CellStyle).Text("Unité").Bold();
                        });

                        foreach (var c in consumptions)
                        {
                            table.Cell().Element(CellStyle).Text(c.Date.ToShortDateString());
                            table.Cell().Element(CellStyle).Text(c.EnergyType);
                            table.Cell().Element(CellStyle).Text(c.Quantity.ToString("0.##"));
                            table.Cell().Element(CellStyle).Text(c.Unit);
                        }

                        IContainer CellStyle(IContainer container) =>
                            container.Border(1)
                                     .BorderColor(Colors.Grey.Darken2)
                                     .Padding(5);
                    });



                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Généré par EnergyTracker • Page ");
                        text.CurrentPageNumber();
                    });
                });
            });

            return document.GeneratePdf();
        }
    }

}
