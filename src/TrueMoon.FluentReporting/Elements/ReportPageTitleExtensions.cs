namespace TrueMoon.FluentReporting.Elements;

public static class ReportPageTitleExtensions
{
    public static IPage<TData> Title<TData>(this IPage<TData> page, Action<ITitle<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var title = new Title<TData>(page);
        action(title);
        page.AddComponent(title);

        return page;
    }
}