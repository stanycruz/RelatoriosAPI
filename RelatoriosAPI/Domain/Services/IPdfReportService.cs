using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Domain.Services
{
    public interface IPdfReportService
    {
        byte[] GeneratePdfReport(string htmlContent);
    }
}
