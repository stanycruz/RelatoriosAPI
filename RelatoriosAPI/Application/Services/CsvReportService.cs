using System.Globalization;
using CsvHelper;
using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Application.Services
{
    public class CsvReportService : ICsvReportService
    {
        public async Task<byte[]> GenerateCsvReportAsync(IEnumerable<Product> products)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                await csv.WriteRecordsAsync(products);
                await writer.FlushAsync();
                return memoryStream.ToArray();
            }
        }
    }
}
