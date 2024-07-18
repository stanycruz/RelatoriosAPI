using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface ICsvReportService
    {
        byte[] GenerateCsvReport(IEnumerable<Product> products);
    }
}
