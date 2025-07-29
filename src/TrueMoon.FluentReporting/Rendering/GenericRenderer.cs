using SkiaSharp;
using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class GenericRenderer<TComponent> : RendererBase<TComponent> where TComponent : IElement
{
    public override void Render(IRenderContext context, TComponent element)
    {
        if (element.Margin?.Top is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Top());
        }
        
        if (element.Foreground is {} foreground)
        {
            var color = SKColor.TryParse(foreground, out var c) ? c : SKColor.Empty;
            using var skPaint = new SKPaint();
            skPaint.Style = SKPaintStyle.Fill;
            skPaint.Color = color;
            context.Canvas.DrawRect(context.Left + element.Margin.Left(), context.Y, (element.Width ?? context.Width) - element.Margin.Left() - element.Margin.Right(), element.Height.ToFloat(), skPaint);
        }
        
        context.AdvanceVerticalSpace(element.Height.ToFloat());
        
        if (element.Margin?.Bottom is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Bottom());
        }
    }
}