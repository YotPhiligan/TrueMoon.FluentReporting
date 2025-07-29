namespace TrueMoon.FluentReporting.Elements;

public class Binding : IBinding
{
    public virtual object? GetRawValue()
    {
        return null;
    }
}

public class Binding<TValue> : Binding, IBinding<TValue>
{
    private readonly Func<TValue?>? _dataDelegate;
    private TValue? _storedValue;

    public Binding(Func<TValue?> dataDelegate)
    {
        _dataDelegate = dataDelegate;
    }
    
    public Binding(TValue? value)
    {
        _storedValue = value;
    }

    public TValue? Value => GetValue();

    private TValue? GetValue()
    {
        if (_dataDelegate != null)
        {
            var value = _dataDelegate.Invoke();
            return value;
        }
        return _storedValue;
    }
}

public class Binding<TData,TValue> : Binding, IBinding<TValue>
{
    private readonly Func<TData,TValue?>? _dataDelegate;
    private readonly IDataSourceProvider _owner;
    private TValue? _storedValue;

    public Binding(IDataSourceProvider owner, Func<TData, TValue?> dataDelegate)
    {
        _dataDelegate = dataDelegate;
        _owner = owner;
    }
    
    public Binding(IDataSourceProvider owner, TValue? value)
    {
        _owner = owner;
        _storedValue = value;
    }

    public TValue? Value => GetValue();

    private TValue? GetValue()
    {
        if (_owner.DataSource is TData data && _dataDelegate != null)
        {
            var value = _dataDelegate.Invoke(data);
            return value;
        }
        return _storedValue;
    }
    
    public override object? GetRawValue() => GetValue();
    
    public static implicit operator TValue(Binding<TData,TValue> binding) => binding.Value;
}

public static class BindingExtensions
{
    public static IBinding<TValue> CreateBinding<TValue,TData>(this IElement<TData> element, Func<TData, TValue?> binding) 
        => new Binding<TData, TValue>(element, binding);
    
    public static IBinding<TValue> CreateBinding<TValue,TData>(this IElement<TData> element, TValue? value) 
        => new Binding<TData, TValue>(element, value);
}