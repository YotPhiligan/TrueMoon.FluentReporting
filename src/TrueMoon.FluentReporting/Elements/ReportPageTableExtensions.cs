namespace TrueMoon.FluentReporting.Elements;

public static class ReportPageTableExtensions
{
    public static IPage<TData> Table<TData>(this IPage<TData> page, Action<ITable<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var gridSetup = new Table<TData>(page);
        action(gridSetup);
        page.AddComponent(gridSetup);

        return page;
    }
}