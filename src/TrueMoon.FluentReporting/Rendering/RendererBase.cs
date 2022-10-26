using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public abstract class RendererBase<TComponent> : IRenderer<TComponent> where TComponent : IElement
{
    public virtual void Render(IRenderContext context, TComponent element)
    {
        
    }

    public void Render(IRenderContext context, IElement element)
    {
        if (element is TComponent c)
        {
            Render(context, c);
        }
    }
}