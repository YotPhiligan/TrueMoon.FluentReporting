namespace TrueMoon.FluentReporting.Elements;

public class Table<TData> : Element<TData>, ITable<TData> 
{
    private ITableColumnConfiguration? _columnConfiguration;
    private Func<TData,IEnumerable<object>> _recordsDelegate;

    public ITableColumnConfiguration<TData,TRecord> WithSource<TRecord>(Func<TData, IEnumerable<TRecord>> action)
    {
        _recordsDelegate = data => action(data).Cast<object>();
        var elements = new TableColumnConfiguration<TData,TRecord>(this);
        _columnConfiguration = elements;
        return elements;
    }

    public IReadOnlyList<ITableColumn> GetColumns() => _columnConfiguration?.GetColumns() ?? [];
    public IEnumerable<object>? GetRecords()
    {
        if (DataSource is TData data)
        {
            var items = _recordsDelegate.Invoke(data);
            return items;
        }
        return [];
    }

    public string? Font { get; set; }
    public float? FontSize { get; set; }
    public string? HeaderFont { get; set; }
    public float? HeaderFontSize { get; set; }
    public bool? IsHeaderFontBold { get; set; }
    public float? RowHeight { get; set; } = 14;
    public float? HeaderHeight { get; set; } = 18;
    public bool? IsHeaderVisible { get; set; } = true;

    public Table(object? parent = default) : base(parent)
    {
    }
}