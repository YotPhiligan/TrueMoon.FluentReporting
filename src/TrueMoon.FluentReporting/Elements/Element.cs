namespace TrueMoon.FluentReporting.Elements;

public abstract class Element : IElement
{
    public VerticalAlignment? VerticalAlignment { get; set; }
    public HorizontalAlignment? HorizontalAlignment { get; set; }
    public Margin? Margin { get; set; }
    public string? Foreground { get; set; }
    public string? Background { get; set; }
    public float? Width { get; set; }
    public float? Height { get; set; }
    
    public object? Parent { get; set; }
    
    public object? DataSource
    {
        get => _dataSource ?? (Parent is IDataSourceProvider s ? s.DataSource : null); 
        set => SetDataSource(value);
    }
    
    private object? _dataSource;
    
    protected virtual void SetParent(object? parent)
    {
        Parent = parent;
    }

    protected virtual void SetDataSource(object? dataSource)
    {
        _dataSource = dataSource;
    }

    public IBinding<bool?> Visibility { get; set; }

    public bool? IsVisible => Visibility.Value;
}

public abstract class Element<TData> : Element, IElement<TData>
{
    protected Element(object? parent = default)
    {
        SetParent(parent);
        
        Visibility = new Binding<TData, bool?>(this, true);
    }
}