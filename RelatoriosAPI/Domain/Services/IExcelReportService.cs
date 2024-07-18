using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface IExcelReportService
    {
        byte[] GenerateExcelReport(IEnumerable<Product> products);
    }
}
