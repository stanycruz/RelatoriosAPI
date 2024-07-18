using OfficeOpenXml;
using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Application.Services
{
    public class ExcelReportService : IExcelReportService
    {
        public byte[] GenerateExcelReport(IEnumerable<Product> products)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Products");

                // Cabeçalhos
                worksheet.Cells[1, 1].Value = "ProductID";
                worksheet.Cells[1, 2].Value = "Name";
                // TODO: Adicione mais colunas conforme necessário

                // Dados
                int row = 2;
                foreach (var product in products)
                {
                    worksheet.Cells[row, 1].Value = product.ProductID;
                    worksheet.Cells[row, 2].Value = product.Name;
                    // TODO: Adicione mais colunas conforme necessário
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
    }
}
