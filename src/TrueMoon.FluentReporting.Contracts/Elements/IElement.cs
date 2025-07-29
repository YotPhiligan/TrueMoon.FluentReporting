namespace TrueMoon.FluentReporting.Elements;

public interface IDataSourceProvider
{
    object? DataSource { get; set; }
}

public interface IElement : IHideable, IDataSourceProvider
{
    VerticalAlignment? VerticalAlignment { get; set; }
    HorizontalAlignment? HorizontalAlignment { get; set; }
    Margin? Margin { get; set; }
    string? Foreground { get; set; }
    string? Background { get; set; }
    float? Width { get; set; }
    float? Height { get; set; }
    
    object? Parent { get; set; }
}

public interface IElement<TData> : IElement;

