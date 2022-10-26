namespace TrueMoon.FluentReporting.Exporting;

public interface IExporter
{
    void Export(IReport report, Stream stream);
}