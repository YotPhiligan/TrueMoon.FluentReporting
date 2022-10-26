using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public interface IRenderer 
{
    void Render(IRenderContext context, IElement element);
}

public interface IRenderer<TElement> : IRenderer where TElement : IElement
{
    void Render(IRenderContext context, TElement element);
}