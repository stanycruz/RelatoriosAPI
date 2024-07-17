using OfficeOpenXml;
using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Application.Services
{
    public class ExcelReportService
    {
        public byte[] GenerateExcelReport(List<Product> products)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Products");

                // Cabeçalhos
                worksheet.Cells[1, 1].Value = "ProductID";
                worksheet.Cells[1, 2].Value = "Name";
                // TODO: Adicione mais colunas conforme necessário

                // Dados
                for (int i = 0; i < products.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = products[i].ProductID;
                    worksheet.Cells[i + 2, 2].Value = products[i].Name;
                    // TODO: Adicione mais colunas conforme necessário
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
    }
}
