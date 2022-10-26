namespace TrueMoon.FluentReporting.Elements;

public class Line<TData> : Element<TData>, ILine<TData>
{
    public Line(IPage<TData> page, IElement? parent = default) : base(page, parent)
    {
    }
}