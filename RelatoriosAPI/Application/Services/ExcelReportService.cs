using OfficeOpenXml;
using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Application.Services
{
    public class ExcelReportService : IExcelReportService
    {
        public async Task<byte[]> GenerateExcelReportAsync(IEnumerable<Product> products)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Products");

                // Cabeçalhos
                worksheet.Cells[1, 1].Value = "ProductKey";
                worksheet.Cells[1, 2].Value = "English Product Name";
                // TODO: Adicione mais colunas conforme necessário

                // Dados
                int row = 2;
                foreach (var product in products)
                {
                    worksheet.Cells[row, 1].Value = product.ProductKey;
                    worksheet.Cells[row, 2].Value = product.EnglishProductName;
                    // TODO: Adicione mais colunas conforme necessário
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return await Task.FromResult(package.GetAsByteArray());
            }
        }
    }
}
