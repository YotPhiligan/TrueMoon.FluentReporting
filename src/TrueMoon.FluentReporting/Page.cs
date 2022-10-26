using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public class Page<TData> : IPage<TData>
{
    private readonly List<IElement> _elements = new ();
    private Func<TData,bool?>? _visibilityDelegate;
    private Func<bool?>? _visibilityDelegateDataLess;
    private bool? _isVisible = true;

    public Page(IReport<TData> report)
    {
        Report = report;
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

    public void SetVisibilityDelegate(Func<TData, bool?> func)
    {
        _visibilityDelegate = func;
    }

    public bool? GetVisibility() => _visibilityDelegate?.Invoke(Report.Data) 
                                    ?? _visibilityDelegateDataLess?.Invoke() 
                                    ?? _isVisible;

    public void SetVisibility(bool value)
    {
        _isVisible = value;
    }

    public void SetVisibilityDelegate(Func<bool?> func)
    {
        _visibilityDelegateDataLess = func;
    }
}