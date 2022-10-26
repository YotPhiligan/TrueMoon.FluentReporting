namespace TrueMoon.FluentReporting.Tests.Rendering;

public class RenderContextTests
{
    [Fact]
    public void RenderContextMargin()
    {
        var page = new Page<object>(new FluentReport<object>());
        page.Size(600, 800);
        page.Margin(50, 20, 50, 50);
        var ctx = new FluentReporting.Rendering.RenderContext(page, null);

        Assert.Equal(50, ctx.Left);
        Assert.Equal(550, ctx.Right);
        Assert.Equal(20, ctx.Top);
        Assert.Equal(750, ctx.Bottom);
        Assert.Equal(500, ctx.Width);
        Assert.Equal(730, ctx.Height);
        Assert.Equal(300, ctx.Center);
    }
}