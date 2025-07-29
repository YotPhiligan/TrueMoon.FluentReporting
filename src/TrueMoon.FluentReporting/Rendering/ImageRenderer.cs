using SkiaSharp;
using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class ImageRenderer : RendererBase<IImage>
{
    public override void Render(IRenderContext context, IImage element)
    {
        if (element.Margin?.Top is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Top());
        }

        var imageData = element.ImageData.Value;
        
        if (!imageData.IsEmpty)
        {
            using var img = SKBitmap.Decode(imageData.Span);

            var width = element.Width ?? context.Width;
            var height = element.Height ?? context.Height;

            var top = context.Y;
            
            var left = element.HorizontalAlignment switch {
                HorizontalAlignment.None => context.Left + element.Margin.Left(),
                HorizontalAlignment.Left => context.Left + element.Margin.Left(),
                HorizontalAlignment.Center => context.Center - width/2f,
                HorizontalAlignment.Right => context.Right - element.Margin.Right() - width,
                HorizontalAlignment.Stretch => context.Left + element.Margin.Left(),
                null => context.Left + element.Margin.Left(),
                _ => context.Left + element.Margin.Left()
            };
        
            var rect = new SKRect(left, top, left + width - element.Margin.Right(), top + height);
            var dest = rect.AspectFit(img.Info.Size);
            context.Canvas.DrawBitmap(img, img.Info.Rect, dest);
        
            context.AdvanceVerticalSpace(dest.Height);
        }

        if (element.Margin?.Bottom is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Bottom());
        }
    }
}