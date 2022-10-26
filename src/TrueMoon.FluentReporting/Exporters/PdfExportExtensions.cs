namespace TrueMoon.FluentReporting.Exporters;

public static class PdfExportExtensions
{
    public static void ExportPdf(this IReport report, Stream stream)
    {
        var exporter = new PdfExporter();
        
        exporter.Export(report, stream);
    }
    
    public static void ExportPdf(this IReport report, string path)
    {
        using var fs = File.OpenWrite(Path.GetFullPath(path));
        report.ExportPdf(fs);
    }
}