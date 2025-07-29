using TrueMoon.FluentReporting.Elements;

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
        page.Visibility = new Binding<TData,bool?>(page, value);
        return page;
    }
    
    public static IPage<TData> Visibility<TData>(this IPage<TData> element, Func<TData,bool?> func)
    {
        element.Visibility = new Binding<TData,bool?>(element, func);
        return element;
    }
    
    public static TElement Visibility<TElement>(this TElement element, Func<bool?> func)
        where TElement : IHideable
    {
        element.Visibility(func);
        return element;
    }
}