namespace TrueMoon.FluentReporting.Elements;

public class Image<TData> : Element<TData>, IImage<TData>
{
    private Memory<byte> _data;
    private Func<TData,Memory<byte>>? _dataDelegate;

    public Image(IPage<TData> page, object? parent = default) : base(page, parent)
    {
    }

    public void SetImageDataDelegate(Func<TData, Memory<byte>> func)
    {
        _dataDelegate = func;
    }

    public void SetImageData(Memory<byte> data)
    {
        _data = data;
    }

    public Memory<byte> GetImageData()
    {
        TData? data = Page.Report.Data;
        return _dataDelegate?.Invoke(data) ?? _data;
    }
}