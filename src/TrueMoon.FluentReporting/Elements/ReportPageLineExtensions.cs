namespace TrueMoon.FluentReporting.Elements;

public static class ReportPageLineExtensions
{
    public static IPage<TData> Line<TData>(this IPage<TData> page, Action<ILine<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var line = new Line<TData>(page);
        action(line);
        page.AddComponent(line);

        return page;
    }
}