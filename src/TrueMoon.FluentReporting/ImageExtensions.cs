using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public static class ImageExtensions
{
    public static IImage<TData> LoadFrom<TData>(this IImage<TData> component, Func<TData,Memory<byte>> func)
    {
        component.ImageData = component.CreateBinding(func);
        return component;
    }
}