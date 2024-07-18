using System.Globalization;
using CsvHelper;
using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Application.Services
{
    public class CsvReportService : ICsvReportService
    {
        public byte[] GenerateCsvReport(IEnumerable<Product> products)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(products);
                writer.Flush();
                return memoryStream.ToArray();
            }
        }
    }
}
