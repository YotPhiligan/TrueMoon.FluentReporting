namespace TrueMoon.FluentReporting.Rendering;

public interface IPageRenderer
{
    void Render(IRenderContext context, IPage page);
}