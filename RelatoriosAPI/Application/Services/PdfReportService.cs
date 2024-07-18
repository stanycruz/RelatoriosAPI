using DinkToPdf;
using DinkToPdf.Contracts;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Application.Services
{
    public class PdfReportService : IPdfReportService
    {
        private readonly IConverter _converter;

        public PdfReportService(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> GeneratePdfReportAsync(string htmlContent)
        {
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects =
                {
                    new ObjectSettings
                    {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return await Task.FromResult(_converter.Convert(doc));
        }
    }
}
