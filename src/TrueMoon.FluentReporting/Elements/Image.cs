namespace TrueMoon.FluentReporting.Elements;

public class Image<TData> : Element<TData>, IImage<TData>
{
    public Image(object? parent = default) : base(parent)
    {
    }

    public IBinding<Memory<byte>> ImageData { get; set; }
}