namespace TrueMoon.FluentReporting.Elements;

public interface ITableColumnConfiguration
{
    IReadOnlyList<ITableColumn> GetColumns();
}

public interface ITableColumnConfiguration<TData,TRecord> : ITableColumnConfiguration
{
    void AddColumn(Action<ITableColumn<TRecord>> action);
}