using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RelatoriosAPI.Application.Services;
using RelatoriosAPI.Domain.Entities;
using RelatoriosAPI.Domain.Services;

namespace RelatoriosAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPdfReportService _pdfReportService;
        private readonly IExcelReportService _excelReportService;
        private readonly ICsvReportService _csvReportService;

        public ReportController(
            IProductService productService,
            IPdfReportService pdfReportService,
            IExcelReportService excelReportService,
            ICsvReportService csvReportService
        )
        {
            _productService = productService;
            _pdfReportService = pdfReportService;
            _excelReportService = excelReportService;
            _csvReportService = csvReportService;
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GetPdfReport()
        {
            var products = await _productService.GetAllProductsAsync();
            var htmlContent = GenerateHtmlContent(products);
            var pdf = _pdfReportService.GeneratePdfReport(htmlContent);
            return File(pdf, "application/pdf", "report.pdf");
        }

        [HttpGet("excel")]
        public async Task<IActionResult> GetExcelReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var products = (await _productService.GetAllProductsAsync()).ToList();
            var excel = _excelReportService.GenerateExcelReport(products);
            return File(
                excel,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "report.xlsx"
            );
        }

        [HttpGet("csv")]
        public async Task<IActionResult> GetCsvReport()
        {
            var products = (await _productService.GetAllProductsAsync()).ToList();
            var csv = _csvReportService.GenerateCsvReport(products);
            return File(csv, "text/csv", "report.csv");
        }

        private string GenerateHtmlContent(IEnumerable<Product> products)
        {
            // TODO: Gera o conteúdo HTML aqui
            var html =
                "<html><body><h1>Products Report</h1><table><tr><th>ProductID</th><th>Name</th></tr>";
            foreach (var product in products)
            {
                html += $"<tr><td>{product.ProductID}</td><td>{product.Name}</td></tr>";
            }
            html += "</table></body></html>";
            return html;
        }
    }
}
