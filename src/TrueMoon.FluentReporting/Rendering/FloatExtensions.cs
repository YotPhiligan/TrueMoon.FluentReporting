namespace TrueMoon.FluentReporting.Rendering;

internal static class FloatExtensions
{
    internal static float ToFloat(this float? value) => value ?? default;
}