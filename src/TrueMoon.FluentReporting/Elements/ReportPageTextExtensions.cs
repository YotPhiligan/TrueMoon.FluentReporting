namespace TrueMoon.FluentReporting.Elements;

public static class ReportPageTextExtensions
{
    public static IPage<TData> Text<TData>(this IPage<TData> page, Action<IText<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var text = new Text<TData>(page);
        action(text);
        page.AddComponent(text);

        return page;
    }
    
    public static IPage<TData> Text<TData>(this IPage<TData> page, string text)
    {
        var component = new Text<TData>(page);
        component.Text(text);
        page.AddComponent(component);

        return page;
    }
}