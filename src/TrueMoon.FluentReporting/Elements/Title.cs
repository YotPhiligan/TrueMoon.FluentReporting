namespace TrueMoon.FluentReporting.Elements;

public class Title<TData> : Text<TData>, ITitle<TData>
{
    public Title(IPage<TData> page, IElement? parent = default) : base(page, parent)
    {
    }
}