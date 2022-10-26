using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class PageRenderer : IPageRenderer
{
    private List<IRenderer> _renderers = new ()
    {
        new TitleRenderer(),
        new TextRenderer(),
        new TableRenderer(),
        new ImageRenderer(),
    };
    public void Render(IRenderContext context, IPage page)
    {
        var components = page.GetComponents();
            
        foreach (var component in components.Where(t=>t.GetVisibility() is true))
        {
            var renderer = ResolveRenderer(component);
            renderer.Render(context, component);
        }
    }

    private IRenderer ResolveRenderer(IElement element) =>
        element switch
        {
            ITitle => _renderers.FirstOrDefault(t=>t is IRenderer<ITitle>) ?? new GenericRenderer<ITitle>(),
            IText => _renderers.FirstOrDefault(t=>t is IRenderer<IText>) ?? new GenericRenderer<IText>(),
            ITable => _renderers.FirstOrDefault(t=>t is IRenderer<ITable>) ?? new GenericRenderer<ITable>(),
            IImage => _renderers.FirstOrDefault(t=>t is IRenderer<IImage>) ?? new GenericRenderer<IImage>(),
            _ => new GenericRenderer<IElement>()
        };
}