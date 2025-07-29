using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public interface IElementsContainer
{
    void AddComponent<T>(T component) where T : IElement;
    IReadOnlyList<IElement> GetComponents();
}

public interface IElementsContainer<TData> : IElementsContainer;