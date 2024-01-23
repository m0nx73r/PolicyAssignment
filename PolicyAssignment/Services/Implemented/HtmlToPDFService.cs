using PolicyAssignment.Services.Interface;
using PuppeteerSharp;
using System.IO;

namespace PolicyAssignment.Services.Implemented
{
    public class HtmlToPDFService : IHtmlToPDFService
    {
        public async Task<byte[]> GetByteArrayAsync(string mappedHtml)
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }))
            using (var page = await browser.NewPageAsync())
            {
                await page.SetContentAsync(mappedHtml);

                var pdfBuffer = await page.PdfDataAsync();

                // Save the PDF to a file (optional)
                var pdfFileName = "generated_pdf.pdf";
                await File.WriteAllBytesAsync(pdfFileName, pdfBuffer);

                // If you only want to return the byte array, you can skip saving to a file
                return pdfBuffer;
            }
        }
    }
}
