namespace TrueMoon.FluentReporting.Elements;

public static class TextExtensions
{
    public static ITitle<TData> Text<TData>(this ITitle<TData> component, Func<TData,object> func)
    {
        component.SetTextDelegate(func);
        return component;
    }
    
    public static IText<TData> Text<TData>(this IText<TData> component, Func<TData,object> func)
    {
        component.SetTextDelegate(func);
        return component;
    }
    
    public static TComponent Text<TComponent>(this TComponent component, string text)
        where TComponent : IText 
    {
        component.SetText(text);
        return component;
    }
    
    public static TComponent Font<TComponent>(this TComponent component, string font, float? fontSize = default, bool? isBold = default, bool? isItalic = default)
        where TComponent : IText
    {
        component.Font = font;
        if (fontSize is {} size)
        {
            component.FontSize = size;
        }

        component.IsBold = isBold;
        component.IsItalic = isItalic;
        
        return component;
    }
}