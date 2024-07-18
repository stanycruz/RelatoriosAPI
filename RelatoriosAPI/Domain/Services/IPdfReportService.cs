using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface IPdfReportService
    {
        Task<byte[]> GeneratePdfReportAsync(string htmlContent);
    }
}
