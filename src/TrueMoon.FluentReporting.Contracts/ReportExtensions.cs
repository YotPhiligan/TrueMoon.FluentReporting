namespace TrueMoon.FluentReporting;

public static class ReportExtensions
{
    public static IReport<TData> Page<TData>(this IReport<TData> template,
        Action<IPage<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        template.AddPage(action);
        return template;
    }
    
    public static IReport<TData> PageSize<TData>(this IReport<TData> template, float width, float height)
    {
        template.PageWidth = width;
        template.PageHeight = height;
        return template;
    }
    
    public static IReport<TData> PageMargin<TData>(this IReport<TData> page, Margin margin)
    {
        page.PageMargin = margin;
        return page;
    }
    
    public static IReport<TData> PageMargin<TData>(this IReport<TData> page, float? left = default, float? top = default, float? right = default, float? bottom = default) 
        => page.PageMargin(new Margin(left, top, right, bottom));
}