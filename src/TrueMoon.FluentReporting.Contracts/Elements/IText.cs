namespace TrueMoon.FluentReporting.Elements;

public interface IText : IElement
{
    string? Font { get; set; }
    float? FontSize { get; set; }
    bool? IsBold { get; set; }
    bool? IsItalic { get; set; }
    
    IBinding<string> TextValue { get; set; }
}

public interface IText<TData> : IText, IElement<TData>;