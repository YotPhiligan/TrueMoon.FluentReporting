using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public static class ElementsContainerExtensions
{
    public static IElementsContainer<TData> Title<TData>(this IElementsContainer<TData> page, Action<ITitle<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var title = new Title<TData>(page);
        action(title);
        page.AddComponent(title);

        return page;
    }
    
    public static TElement Title<TElement,TData>(this TElement page, Action<ITitle<TData>> action)
        where TElement : IElementsContainer<TData>
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var title = new Title<TData>(page);
        action(title);
        page.AddComponent(title);

        return page;
    }

    public static IElementsContainer<TData> Line<TData>(this IElementsContainer<TData> page, Action<ILine<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var line = new Line<TData>(page);
        action(line);
        page.AddComponent(line);
    
        return page;
    }
    
    public static IElementsContainer<TData> Image<TData>(this IElementsContainer<TData> page, Action<IImage<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var image = new Image<TData>(page);
        action(image);
        page.AddComponent(image);

        return page;
    }
    
    public static IElementsContainer<TData> Table<TData>(this IElementsContainer<TData> page, Action<ITable<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var gridSetup = new Table<TData>(page);
        action(gridSetup);
        page.AddComponent(gridSetup);

        return page;
    }
    
    public static IElementsContainer<TData> Text<TData>(this IElementsContainer<TData> container, Action<IText<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var text = new Text<TData>(container);
        action(text);
        container.AddComponent(text);

        return container;
    }
    
    public static IElementsContainer<TData> Text<TData>(this IElementsContainer<TData> container, string text)
    {
        var component = new Text<TData>(container);
        component.Text(text);
        container.AddComponent(component);

        return container;
    }
    
    public static TContainer BlankSpace<TContainer>(this TContainer container, float height) 
        where TContainer : IElementsContainer
    {
        var blankSpace = new EmptyElement();
        blankSpace.Height = height;
        container.AddComponent(blankSpace);

        return container;
    }
    
    public static IElementsContainer<TData> List<TData,TRecord>(this IElementsContainer<TData> container, Func<TData,IEnumerable<TRecord>> selector, Action<IElementsContainer<TRecord>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        
        var list = new ElementList<TData,TRecord>(container, selector);
        action(list);
        container.AddComponent(list);

        return container;
    }
}