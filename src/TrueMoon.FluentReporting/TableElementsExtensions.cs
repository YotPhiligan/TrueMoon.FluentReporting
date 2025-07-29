using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public static class TableElementsExtensions
{
    public static ITableColumnConfiguration<TData,TRecord> Column<TData,TRecord>(this ITableColumnConfiguration<TData,TRecord> setup, Action<ITableColumn<TRecord>> action)
    {
        setup.AddColumn(action);
        return setup;
    }
}