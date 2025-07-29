using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public static class RendererResolver
{
    private static readonly TitleRenderer TitleRenderer = new();
    private static readonly TextRenderer TextRenderer = new();
    private static readonly TableRenderer TableRenderer = new();
    private static readonly ImageRenderer ImageRenderer = new();
    private static readonly ElementListRenderer ElementListRenderer = new();

    public static IRenderer Resolve(IElement element) =>
        element switch
        {
            ITitle => TitleRenderer,
            IText => TextRenderer,
            ITable => TableRenderer,
            IImage => ImageRenderer,
            IElementList => ElementListRenderer,
            _ => new GenericRenderer<IElement>()
        };
}