using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface IExcelReportService
    {
        Task<byte[]> GenerateExcelReportAsync(IEnumerable<Product> products);
    }
}
