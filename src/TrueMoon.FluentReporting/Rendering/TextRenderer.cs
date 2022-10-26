using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class TextRenderer : RendererBase<IText>, IRenderer<IText>
{
    public override void Render(IRenderContext context, IText element)
    {
        context.RenderText(element, defaultFontSize:8);
    }
}