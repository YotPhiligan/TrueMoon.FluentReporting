namespace TrueMoon.FluentReporting.Rendering;

internal static class MarginExtensions
{
    internal static float Left(this Margin? value) => value?.Left.ToFloat()?? default;
    internal static float Top(this Margin? value) => value?.Top.ToFloat()?? default;
    internal static float Right(this Margin? value) => value?.Right.ToFloat()?? default;
    internal static float Bottom(this Margin? value) => value?.Bottom.ToFloat()?? default;
}