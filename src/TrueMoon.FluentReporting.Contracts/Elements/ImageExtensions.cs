namespace TrueMoon.FluentReporting.Elements;

public static class ImageExtensions
{
    public static IImage<TData> LoadFrom<TData>(this IImage<TData> component, Func<TData,Memory<byte>> func)
    {
        component.SetImageDataDelegate(func);
        return component;
    }
}