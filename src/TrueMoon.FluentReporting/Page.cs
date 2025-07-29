using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public class Page<TData> : IPage<TData>
{
    private readonly List<IElement> _elements = new ();

    public Page(IReport<TData> report)
    {
        Report = report;

        Visibility = new Binding<TData, bool?>(this, true);
    }

    public int PageNumber { get; set; }
    public float? Width { get; set; }
    public float? Height { get; set; }
    public Margin? Margin { get; set; }

    public void AddComponent<T>(T component) where T : IElement
    {
        _elements.Add(component);
    }

    public IReadOnlyList<IElement> GetComponents() => _elements;

    public IReport<TData> Report { get; }

    public bool? IsVisible => Visibility?.Value;
    public IBinding<bool?> Visibility { get; set; }

    private object? _dataSource;
    public object? DataSource
    {
        get => _dataSource ?? Report?.DataSource; 
        set => _dataSource = value;
    }
}