using SkiaSharp;
using TrueMoon.FluentReporting.Exporting;
using TrueMoon.FluentReporting.Rendering;

namespace TrueMoon.FluentReporting.Exporters;

public class PdfExporter : IExporter
{
    private readonly IPageRenderer _pageRenderer;

    public PdfExporter(IPageRenderer? pageRenderer = default)
    {
        _pageRenderer = pageRenderer ?? new PageRenderer();
    }
    
    public void Export(IReport report, Stream stream)
    {
        var metadata = new SKDocumentPdfMetadata
        {
            Author = report.Author,
            Creation = report.Creation ?? DateTime.Now,
            Creator = report.Creator,
            Modified = report.Modified ?? DateTime.Now,
            Producer = report.Producer,
            Subject = report.Subject,
            Title = report.Title,
            EncodingQuality = 100
        };
        
        using var document = SKDocument.CreatePdf(stream, metadata);

        var pages = report.GetPages();

        foreach (var page in pages)
        {
            if (page.IsVisible is not true)
            {
                continue; 
            }
            var pageWidth = page.Width ?? 600;
            var pageHeight = page.Height ?? 800;
            
            using var pdfCanvas = document.BeginPage(pageWidth, pageHeight);

            var context = new RenderContext(page,pdfCanvas);
            
            _pageRenderer.Render(context,page);

            document.EndPage();
        }

        // end the doc
        document.Close();
    }
}