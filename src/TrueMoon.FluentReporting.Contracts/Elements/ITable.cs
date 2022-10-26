namespace TrueMoon.FluentReporting.Elements;

public interface ITable : IElement
{
    IReadOnlyList<ITableColumn> GetColumns();
    IEnumerable<object>? GetRecords();
    
    string? Font { get; set; }
    float? FontSize { get; set; }
    
    string? HeaderFont { get; set; }
    float? HeaderFontSize { get; set; }
    bool? IsHeaderFontBold { get; set; }
    
    float? RowHeight { get; set; }
    float? HeaderHeight { get; set; }
    bool? IsHeaderVisible { get; set; }
}

public interface ITable<TData> : ITable, IElement<TData>
{
    ITableColumnConfiguration<TData,TRecord> WithSource<TRecord>(Func<TData,IEnumerable<TRecord>> action);
}