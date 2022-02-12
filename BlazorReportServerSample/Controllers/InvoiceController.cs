using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace BlazorReportServerSample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet("invoice")]
        public async Task<IActionResult> GetInvoice()
        {
            await new BrowserFetcher().DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://localhost:7044/");
            var stream = await page.PdfStreamAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Bottom = "0.5in",
                    Left = "0.5in",
                    Right = "0.5in",
                    Top = "0.5in"
                }
            });
            await browser.CloseAsync();

            return File(stream, "application/pdf", "invoice.pdf");
        }
    }
}
