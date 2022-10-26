namespace TrueMoon.FluentReporting.Elements;

public static class ElementExtensions
{
    public static TComponent Size<TComponent>(this TComponent component, float? width = default, float? height = default) 
        where TComponent : IElement
    {
        component.Width = width;
        component.Height = height;
        return component;
    }
    
    public static TComponent Alignment<TComponent>(this TComponent component, VerticalAlignment? verticalAlignment = default, HorizontalAlignment? horizontalAlignment = default) 
        where TComponent : IElement
    {
        if (verticalAlignment is { } vAlignment)
        {
            component.VerticalAlignment = vAlignment;
        }
        
        if (horizontalAlignment is { } hAlignment)
        {
            component.HorizontalAlignment = hAlignment;
        }
        return component;
    }
    
    public static TComponent VerticalAlignment<TComponent>(this TComponent component, VerticalAlignment alignment) 
        where TComponent : IElement
    {
        component.VerticalAlignment = alignment;
        return component;
    }
    
    public static TComponent HorizontalAlignment<TComponent>(this TComponent component, HorizontalAlignment alignment) 
        where TComponent : IElement
    {
        component.HorizontalAlignment = alignment;
        return component;
    }
    
    public static TComponent Margin<TComponent>(this TComponent component, Margin margin) 
        where TComponent : IElement
    {
        component.Margin = margin;
        return component;
    }
    
    public static TComponent Margin<TComponent>(this TComponent component, float? left = default, float? top = default, float? right = default, float? bottom = default)
        where TComponent : IElement
    {
        component.Margin = new Margin(left, top, right, bottom);
        return component;
    }
    
    public static TComponent Foreground<TComponent>(this TComponent component, string foreground) 
        where TComponent : IElement
    {
        component.Foreground = foreground;
        return component;
    }
    
    public static TComponent Background<TComponent>(this TComponent component, string background) 
        where TComponent : IElement
    {
        component.Background = background;
        return component;
    }

    public static TComponent Visibility<TComponent>(this TComponent component, bool value) 
        where TComponent : IElement
    {
        component.SetVisibility(value);
        return component;
    }
    
    public static IElement<TData> Visibility<TData>(this IElement<TData> element, Func<TData,bool?> func)
    {
        element.SetVisibilityDelegate(func);
        return element;
    }
    
    public static TComponent Visibility<TComponent>(this TComponent component, Func<bool?> func) 
        where TComponent : IElement
    {
        component.SetVisibilityDelegate(func);
        return component;
    }

    public static TTarget As<TTarget>(this IElement component) 
        where TTarget : IElement
    {
        return (TTarget)component;
    }
}