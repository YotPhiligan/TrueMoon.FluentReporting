using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public static class TableColumnExtensions
{
    public static TColumn Header<TColumn>(this TColumn column, string header)
        where TColumn : ITableColumn
    {
        column.Header = header;
        return column;
    }
    
    public static ITableColumn<TData> Value<TData>(this ITableColumn<TData> column, Func<TData,object> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        column.SetValue(func);
        return column;
    }
    
    public static TColumn Foreground<TColumn>(this TColumn column, string foreground)
        where TColumn : ITableColumn
    {
        column.SetForeground(foreground);
        return column;
    }
    
    public static ITableColumn<TData> Foreground<TData>(this ITableColumn<TData> column, Func<TData,string> func)
    {
        column.SetForeground(func);
        return column;
    }
    
    public static TColumn Background<TColumn>(this TColumn column, string background)
        where TColumn : ITableColumn
    {
        column.SetBackground(background);
        return column;
    }
    
    public static ITableColumn<TData> Background<TData>(this ITableColumn<TData> column, Func<TData,string> func)
    {
        column.SetBackground(func);
        return column;
    }
    
    public static TColumn Width<TColumn>(this TColumn column, string width)
        where TColumn : ITableColumn
    {
        column.WidthProportion = width;
        return column;
    }    
    
    public static TColumn Width<TColumn>(this TColumn column, float width)
        where TColumn : ITableColumn
    {
        column.Width = width;
        return column;
    }
    
    public static ITableColumn<TData> Alignment<TData>(this ITableColumn<TData> component, 
        VerticalAlignment? verticalAlignment = default, 
        HorizontalAlignment? horizontalAlignment = default)
    {
        if (verticalAlignment is { } vAlignment)
        {
            component.ContentVerticalAlignment = vAlignment;
        }
        
        if (horizontalAlignment is { } hAlignment)
        {
            component.ContentHorizontalAlignment = hAlignment;
        }
        return component;
    }
    
    public static ITableColumn<TData> VerticalAlignment<TData>(this ITableColumn<TData> component, VerticalAlignment alignment)
    {
        component.ContentVerticalAlignment = alignment;
        return component;
    }
    
    public static ITableColumn<TData> HorizontalAlignment<TData>(this ITableColumn<TData> component, HorizontalAlignment alignment)
    {
        component.ContentHorizontalAlignment = alignment;
        return component;
    }
    
    public static ITableColumn<TData> HeaderFont<TData>(this ITableColumn<TData> element, string font, float? fontSize = default, bool? isBold = default)
    {
        element.HeaderFont = font;
        element.HeaderFontSize = fontSize;
        element.IsHeaderFontBold = isBold;
        return element;
    }
    
    public static ITableColumn<TData> Font<TData>(this ITableColumn<TData> element, string font, float? fontSize = default, bool? isBold = default)
    {
        element.Font = font;
        element.FontSize = fontSize;
        element.IsBold = isBold;
        
        return element;
    }
}