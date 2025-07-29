namespace TrueMoon.FluentReporting.Rendering;

public class PageRenderer : IPageRenderer
{
    public void Render(IRenderContext context, IPage page)
    {
        var components = page.GetComponents();
            
        foreach (var component in components)
        {
            var renderer = RendererResolver.Resolve(component);
            renderer.Render(context, component);
        }
    }
}