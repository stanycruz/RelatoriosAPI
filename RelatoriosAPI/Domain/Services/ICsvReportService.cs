using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface ICsvReportService
    {
        Task<byte[]> GenerateCsvReportAsync(IEnumerable<Product> products);
    }
}
