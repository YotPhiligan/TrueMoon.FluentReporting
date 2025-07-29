namespace TrueMoon.FluentReporting.Elements;

public class Line<TData> : Element<TData>, ILine<TData>
{
    public Line(object? parent = default) : base(parent)
    {
    }
}