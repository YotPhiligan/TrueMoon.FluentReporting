namespace TrueMoon.FluentReporting.Elements;

public abstract class Element : IElement
{
    private bool? _isVisible = true;
    private Func<bool?>? _visibilityDelegateDataLess;
    public VerticalAlignment? VerticalAlignment { get; set; }
    public HorizontalAlignment? HorizontalAlignment { get; set; }
    public Margin? Margin { get; set; }
    public string? Foreground { get; set; }
    public string? Background { get; set; }
    public float? Width { get; set; }
    public float? Height { get; set; }
    
    public object? Parent { get; private set; }
    public void SetParent(object? component)
    {
        Parent = component;
    }

    public virtual bool? GetVisibility() => _visibilityDelegateDataLess?.Invoke() ?? _isVisible;

    public void SetVisibility(bool value)
    {
        _isVisible = value;
    }

    public void SetVisibilityDelegate(Func<bool?> func)
    {
        _visibilityDelegateDataLess = func;
    }
}

public abstract class Element<TData> : Element, IElement<TData>
{
    private Func<TData,bool?>? _visibilityDelegate;

    protected Element(IPage<TData> page, object? parent = default)
    {
        Page = page;
        SetParent(parent ?? page);
    }
    
    public IPage<TData> Page { get; }
    public void SetVisibilityDelegate(Func<TData, bool?> func)
    {
        _visibilityDelegate = func;
    }

    public override bool? GetVisibility()
    {
        TData? data = Page.Report.Data;
        return _visibilityDelegate?.Invoke(data) ?? base.GetVisibility();
    }
}

public class EmptyElement : Element
{
    
}