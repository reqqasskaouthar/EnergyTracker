using EnergyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyTracker.Infrastructure.Exporters
{
    public class ExcelExporter : IExcelExporter
    {
        public byte[] ExportUsersToExcel(List<User> users)
        {
            using var workbook = new ClosedXML.Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Users");

            worksheet.Cell(1, 1).Value = "UserId";
            worksheet.Cell(1, 2).Value = "FirstName";
            worksheet.Cell(1, 3).Value = "LastName";
            worksheet.Cell(1, 4).Value = "Email";
            worksheet.Cell(1, 5).Value = "CreatedAt";

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                worksheet.Cell(i + 2, 1).Value = user.UserId.ToString() ;
                worksheet.Cell(i + 2, 2).Value = user.FirstName;
                worksheet.Cell(i + 2, 3).Value = user.LastName;
                worksheet.Cell(i + 2, 4).Value = user.Email;
                worksheet.Cell(i + 2, 5).Value = user.CreatedAT;
            }

            using var stream = new System.IO.MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
