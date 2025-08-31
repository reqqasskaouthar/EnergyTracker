using ClosedXML.Excel;
using EnergyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Infrastructure.Exporters
{
    public class ExcelExporterConsumption : IExcelExporterConsumption
    {
        public byte[] ExportConsumptionsToExcel(List<Consumption> consumptions)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Consumptions");

            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "UserId";
            worksheet.Cell(1, 3).Value = "User Email"; 
            worksheet.Cell(1, 4).Value = "Date";
            worksheet.Cell(1, 5).Value = "Energy Type";
            worksheet.Cell(1, 6).Value = "Quantity";
            worksheet.Cell(1, 7).Value = "Unit";

            for (int i = 0; i < consumptions.Count; i++)
            {
                var c = consumptions[i];
                worksheet.Cell(i + 2, 1).Value = c.ConsumptionId.ToString();
                worksheet.Cell(i + 2, 2).Value = c.UserId.ToString();
                worksheet.Cell(i + 2, 3).Value = c.User?.Email ?? "";
                worksheet.Cell(i + 2, 4).Value = c.Date.ToString("yyyy-MM-dd");
                worksheet.Cell(i + 2, 5).Value = c.EnergyType;
                worksheet.Cell(i + 2, 6).Value = c.Quantity;
                worksheet.Cell(i + 2, 7).Value = c.Unit;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}

