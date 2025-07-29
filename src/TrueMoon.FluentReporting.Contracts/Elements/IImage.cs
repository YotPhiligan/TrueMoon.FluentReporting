namespace TrueMoon.FluentReporting.Elements;

public interface IImage : IElement
{
    IBinding<Memory<byte>> ImageData { get; set; }
}

public interface IImage<TData> : IImage, IElement<TData>
{
    
}