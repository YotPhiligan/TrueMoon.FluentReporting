namespace TrueMoon.FluentReporting;

public static class ReportPageExtensions
{
    public static IPage<TData> Size<TData>(this IPage<TData> page, float width, float height)
    {
        page.Width = width;
        page.Height = height;
        return page;
    }
    public static IPage<TData> Margin<TData>(this IPage<TData> page, Margin margin)
    {
        page.Margin = margin;
        return page;
    }
    
    public static IPage<TData> Margin<TData>(this IPage<TData> page, float? left = default, float? top = default, float? right = default, float? bottom = default) 
        => page.Margin(new Margin(left, top, right, bottom));
    
    public static IPage<TData> Visibility<TData>(this IPage<TData> page, bool value)
    {
        page.SetVisibility(value);
        return page;
    }
    
    public static IPage<TData> Visibility<TData>(this IPage<TData> element, Func<TData,bool?> func)
    {
        element.SetVisibilityDelegate(func);
        return element;
    }
    
    public static IPage<TData> Visibility<TData>(this IPage<TData> element, Func<bool?> func)
    {
        element.SetVisibilityDelegate(func);
        return element;
    }
}