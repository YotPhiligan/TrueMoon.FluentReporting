using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public interface IPage : IHideable, IElementsContainer, IDataSourceProvider
{
    int PageNumber { get; set; }
    float? Width { get; set; }
    float? Height { get; set; }
    Margin? Margin { get; set; }
}

public interface IPage<TData> : IPage, IElementsContainer<TData>
{
    IReport<TData> Report { get; }
}