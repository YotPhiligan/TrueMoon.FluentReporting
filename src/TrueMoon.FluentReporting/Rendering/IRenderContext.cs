using SkiaSharp;

namespace TrueMoon.FluentReporting.Rendering;

public interface IRenderContext
{
    SKCanvas Canvas { get; }
    float Y { get; }
    float Left { get; }
    float Top { get; }
    float Right { get; }
    float Bottom { get; }
    float Center { get; }
    
    float Width { get; }
    float Height { get; }
    void AdvanceVerticalSpace(float height);
    void AdjustHorizontalSpace(float width);
}