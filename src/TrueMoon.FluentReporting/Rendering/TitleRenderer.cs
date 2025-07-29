using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class TitleRenderer : RendererBase<ITitle>
{
    public override void Render(IRenderContext context, ITitle element)
    {
        context.RenderText(element);
    }
}