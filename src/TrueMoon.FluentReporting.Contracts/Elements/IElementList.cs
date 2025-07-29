using System.Collections;

namespace TrueMoon.FluentReporting.Elements;

public interface IElementList : IElement, IElementsContainer
{
    IEnumerable GetItems();
}

public interface IElementList<TData, TRecord> : IElementList, IElement<TData>, IElementsContainer<TRecord>;