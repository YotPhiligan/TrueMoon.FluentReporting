namespace TrueMoon.FluentReporting.Elements;

public static class TableExtensions
{
    public static ITable<TData> HideHeader<TData>(this ITable<TData> element)
    {
        element.IsHeaderVisible = false;
        return element;
    }
    
    public static ITable<TData> HeaderHeight<TData>(this ITable<TData> element, float? height = default)
    {
        element.HeaderHeight = height;
        return element;
    }
    
    public static ITable<TData> RowHeight<TData>(this ITable<TData> element, float? height = default)
    {
        element.RowHeight = height;
        return element;
    }
    
    public static ITable<TData> HeaderFont<TData>(this ITable<TData> element, string font, float? fontSize = default, bool? isBold = default)
    {
        element.HeaderFont = font;
        element.HeaderFontSize = fontSize;
        element.IsHeaderFontBold = isBold;
        return element;
    }
    
    public static ITable<TData> Font<TData>(this ITable<TData> element, string font, float? fontSize = default, bool? isBold = default)
    {
        element.Font = font;
        element.FontSize = fontSize;
        
        return element;
    }
}