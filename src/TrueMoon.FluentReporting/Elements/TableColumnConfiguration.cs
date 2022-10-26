namespace TrueMoon.FluentReporting.Elements;

public class TableColumnConfiguration<TData,TRecord> : ITableColumnConfiguration<TData,TRecord>
{
    private List<ITableColumn> _columns = new ();
    private readonly ITable<TData> _table;

    public TableColumnConfiguration(ITable<TData> table)
    {
        _table = table;
    }
    
    public void AddColumn(Action<ITableColumn<TRecord>> action)
    {
        var column = new TableColumn<TRecord>(_table);
        action(column);
        _columns.Add(column);
    }

    public IReadOnlyList<ITableColumn> GetColumns() => _columns;
}