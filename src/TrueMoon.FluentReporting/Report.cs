namespace TrueMoon.FluentReporting;

public static class Report
{
    public static IReport<TData> Create<TData>(Action<IReport<TData>> action, TData? data = default)
    {
        ArgumentNullException.ThrowIfNull(action);

        var report = new FluentReport<TData>();
        action(report);
        if (data != null)
        {
            report.SetDataSource(data);
        }
        return report;
    }
}