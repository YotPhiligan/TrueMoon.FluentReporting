namespace TrueMoon.FluentReporting.Elements;

public interface ITableColumn
{
    string? Header { get; set; }
    void SetValue(Func<object,object?> func);
    string? GetForeground(object? o = default);
    string? GetBackground(object? o = default);
    void SetForeground(string foreground);
    void SetBackground(string background);
    float? Width { get; set; }
    string? WidthProportion { get; set; }
    VerticalAlignment? ContentVerticalAlignment { get; set; }
    HorizontalAlignment? ContentHorizontalAlignment { get; set; }

    string? Font { get; set; }
    float? FontSize { get; set; }
    bool? IsBold { get; set; }
    
    string? HeaderFont { get; set; }
    float? HeaderFontSize { get; set; }
    bool? IsHeaderFontBold { get; set; }

    object? GetValue(object o);
    
    ITable Table { get; }
}
public interface ITableColumn<TData> : ITableColumn
{
    void SetValue(Func<TData,object> func);
    void SetForeground(Func<TData,string> func);
    void SetBackground(Func<TData,string> func);
}
