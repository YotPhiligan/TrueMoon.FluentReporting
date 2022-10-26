namespace TrueMoon.FluentReporting.Elements;

public class TableColumn : ITableColumn
{
    private Func<object,object?>? _valueDelegate;
    private string? _foreground;
    private string? _background;

    public TableColumn(ITable table)
    {
        Table = table;
    }

    public string? Header { get; set; }
    public void SetValue(Func<object,object?> func)
    {
        _valueDelegate = func;
    }

    public virtual string? GetForeground(object? o = default)
    {
        return _foreground;
    }

    public virtual string? GetBackground(object? o = default)
    {
        return _background;
    }

    public void SetForeground(string foreground)
    {
        _foreground = foreground;
    }

    public void SetBackground(string background)
    {
        _background = background;
    }

    public float? Width { get; set; }
    public string? WidthProportion { get; set; }
    public VerticalAlignment? ContentVerticalAlignment { get; set; }
    public HorizontalAlignment? ContentHorizontalAlignment { get; set; }
    public string? Font { get; set; }
    public float? FontSize { get; set; }
    public bool? IsBold { get; set; }
    public string? HeaderFont { get; set; }
    public float? HeaderFontSize { get; set; }
    public bool? IsHeaderFontBold { get; set; }
    public virtual object? GetValue(object o) => _valueDelegate?.Invoke(o);
    public ITable Table { get; }
}

public class TableColumn<TRecord> : TableColumn, ITableColumn<TRecord>
{
    private Func<TRecord,object>? _valueDelegate;
    private Func<TRecord,string>? _foregroundDelegate;
    private Func<TRecord,string>? _backgroundDelegate;

    public override object? GetValue(object o) => _valueDelegate?.Invoke((TRecord)o);

    public void SetValue(Func<TRecord, object> func)
    {
        _valueDelegate = func;
    }

    public void SetForeground(Func<TRecord, string> func)
    {
        _foregroundDelegate = func;
    }

    public void SetBackground(Func<TRecord, string> func)
    {
        _backgroundDelegate = func;
    }

    public override string? GetForeground(object? o = default)
    {
        var record = o is TRecord r ? r : default;
        return _foregroundDelegate?.Invoke(record) ?? base.GetForeground(o);
    }

    public override string? GetBackground(object? o = default)
    {
        var record = o is TRecord r ? r : default;
        return _backgroundDelegate?.Invoke(record) ?? base.GetBackground(o);
    }

    public TableColumn(ITable table) : base(table)
    {
    }
}