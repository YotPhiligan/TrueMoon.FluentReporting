namespace TrueMoon.FluentReporting.Elements;

public static class ReportPageImageExtensions
{
    public static IPage<TData> Image<TData>(this IPage<TData> page, Action<IImage<TData>> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var image = new Image<TData>(page);
        action(image);
        page.AddComponent(image);

        return page;
    }
}