namespace TrueMoon.FluentReporting.Elements;

public interface IText : IElement
{
    string? Font { get; set; }
    float? FontSize { get; set; }
    bool? IsBold { get; set; }
    bool? IsItalic { get; set; }
    void SetText(string text);
    string GetText();
}

public interface IText<TData> : IText, IElement<TData>
{
    void SetTextDelegate(Func<TData?,object?> func);
}