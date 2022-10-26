namespace TrueMoon.FluentReporting.Elements;

public interface IElement : IHideable
{
    VerticalAlignment? VerticalAlignment { get; set; }
    HorizontalAlignment? HorizontalAlignment { get; set; }
    Margin? Margin { get; set; }
    string? Foreground { get; set; }
    string? Background { get; set; }
    float? Width { get; set; }
    float? Height { get; set; }
    
    object? Parent { get; }

    void SetParent(object? component);
}

public interface IElement<TData> : IElement, IHideable<TData>
{
    IPage<TData> Page { get; }
}

