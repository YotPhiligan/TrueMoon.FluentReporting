namespace TrueMoon.FluentReporting.Elements;

public class Title<TData> : Text<TData>, ITitle<TData>
{
    public Title(object? parent = default) : base(parent)
    {
    }
}