using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public interface IPage : IHideable
{
    int PageNumber { get; set; }
    float? Width { get; set; }
    float? Height { get; set; }
    Margin? Margin { get; set; }
    
    void AddComponent<T>(T component) where T : IElement;
    IReadOnlyList<IElement> GetComponents();
}

public interface IPage<TData> : IPage, IHideable<TData>
{
    IReport<TData> Report { get; }
}