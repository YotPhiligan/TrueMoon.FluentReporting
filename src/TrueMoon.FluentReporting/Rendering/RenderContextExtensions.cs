using SkiaSharp;
using Topten.RichTextKit;
using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public static class RenderContextExtensions
{
    public static void RenderText<TTextElement>(this IRenderContext context,
        TTextElement textElement,
        string defaultFont = "Arial",
        float defaultFontSize = 14) 
        where TTextElement : IText
    {
        if (textElement.Margin?.Top is {})
        {
            context.AdvanceVerticalSpace(textElement.Margin.Top());
        }
        var str = textElement.GetText();
        
        var tb = new TextBlock();
        
        tb.MaxWidth = textElement.Width ?? context.Width;
        tb.Alignment = textElement.HorizontalAlignment switch {
            HorizontalAlignment.None => TextAlignment.Center,
            HorizontalAlignment.Left => TextAlignment.Left,
            HorizontalAlignment.Center => TextAlignment.Center,
            HorizontalAlignment.Right => TextAlignment.Right,
            HorizontalAlignment.Stretch => TextAlignment.Auto,
            null => TextAlignment.Auto,
            _ => TextAlignment.Auto
        };
        
        tb.AddText(str, new Style
        {
            FontFamily = textElement.Font ?? defaultFont, 
            FontSize = textElement.FontSize ?? defaultFontSize,
            FontWeight = textElement.IsBold is true ? 600 : 400,
            FontItalic = textElement.IsItalic is true,
            TextColor = textElement.Foreground is {} foreground && SKColor.TryParse(foreground, out var c) ? c : SKColors.Black
        });

        var x = tb switch {
            {Alignment:TextAlignment.Auto, MaxWidth: {}} => context.Left + textElement.Margin.Left(),
            {Alignment:TextAlignment.Left, MaxWidth: {}} => context.Left + textElement.Margin.Left(),
            {Alignment:TextAlignment.Center, MaxWidth: {}} => context.Left + textElement.Margin.Left(),
            {Alignment:TextAlignment.Right, MaxWidth: {}} => context.Left + textElement.Margin.Left(),
            
            {Alignment:TextAlignment.Auto, MaxWidth: null} => context.Left + textElement.Margin.Left(),
            {Alignment:TextAlignment.Left, MaxWidth: null} => context.Left + textElement.Margin.Left(),
            {Alignment:TextAlignment.Center, MaxWidth: null} => context.Center - tb.MeasuredWidth/2f + textElement.Margin.Left(),
            {Alignment:TextAlignment.Right, MaxWidth: null} => context.Right - tb.MeasuredWidth + textElement.Margin.Left(),
            
            _ => context.Left + textElement.Margin.Left()
        };
        
        tb.Paint(context.Canvas, new SKPoint(x, context.Y));

        var h = tb.MeasuredHeight;
        
        context.AdvanceVerticalSpace(h);
        
        if (textElement.Margin?.Bottom is {})
        {
            context.AdvanceVerticalSpace(textElement.Margin.Bottom());
        }
    }
}