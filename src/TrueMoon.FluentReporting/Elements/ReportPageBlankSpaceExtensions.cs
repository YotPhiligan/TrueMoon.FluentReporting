namespace TrueMoon.FluentReporting.Elements;

public static class ReportPageBlankSpaceExtensions
{
    public static IPage<TData> BlankSpace<TData>(this IPage<TData> page, float height)
    {
        var blankSpace = new EmptyElement();
        blankSpace.Height = height;
        page.AddComponent(blankSpace);

        return page;
    }
}