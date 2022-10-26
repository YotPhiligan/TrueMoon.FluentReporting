namespace TrueMoon.FluentReporting.Elements;

public interface IImage : IElement
{
    void SetImageData(Memory<byte> data);
    Memory<byte> GetImageData();
}

public interface IImage<TData> : IImage, IElement<TData>
{
    void SetImageDataDelegate(Func<TData, Memory<byte>> func);
}