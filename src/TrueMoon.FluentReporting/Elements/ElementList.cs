using System.Collections;

namespace TrueMoon.FluentReporting.Elements;

public class ElementList<TData,TRecord> : Element<TData>, IElementList<TData, TRecord>
{
    private readonly Func<TData, IEnumerable<TRecord>> _selector;
    private readonly List<IElement> _elements = [];

    public ElementList(object? parent, Func<TData, IEnumerable<TRecord>> selector) : base(parent)
    {
        _selector = selector;
    }

    public void AddComponent<T>(T component) where T : IElement
    {
        _elements.Add(component);
    }

    public IReadOnlyList<IElement> GetComponents() => _elements;
    
    public IEnumerable GetItems()
    {
        if (DataSource is TData data)
        {
            var items = _selector(data);
            return items;
        }
        return default;
    }
}