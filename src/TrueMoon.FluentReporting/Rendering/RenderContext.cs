using SkiaSharp;

namespace TrueMoon.FluentReporting.Rendering;

public class RenderContext : IRenderContext
{
    private readonly IPage _page;

    public RenderContext(IPage page, SKCanvas canvas)
    {
        _page = page;
        Canvas = canvas;
        AdvanceVerticalSpace(Top);
    }

    public SKCanvas Canvas { get; }
    public float Y { get; private set; }
    public float Left => _page.Margin.Left();
    public float Top => _page.Margin.Top();
    public float Right => _page.Width.ToFloat() - _page.Margin.Right();
    public float Bottom => _page.Height.ToFloat() - _page.Margin.Bottom();
    public float Center => Right - Width / 2f;

    public float Width => Right - Left;
    public float Height => Bottom - Top;

    public void AdvanceVerticalSpace(float height)
    {
        Y += height;
    }

    public void AdjustHorizontalSpace(float width)
    {
        throw new NotImplementedException();
    }
}