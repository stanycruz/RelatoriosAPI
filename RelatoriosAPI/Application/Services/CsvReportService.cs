using System.Globalization;
using CsvHelper;
using RelatoriosAPI.Domain.Entities;

namespace RelatoriosAPI.Application.Services
{
    public class CsvReportService
    {
        public byte[] GenerateCsvReport(List<Product> products)
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
