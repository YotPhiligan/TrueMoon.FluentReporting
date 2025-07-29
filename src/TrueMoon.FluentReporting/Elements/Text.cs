namespace TrueMoon.FluentReporting.Elements;

public class Text<TData> : Element<TData>, IText<TData>
{
    public string? Font { get; set; }
    public float? FontSize { get; set; }
    public bool? IsBold { get; set; }
    public bool? IsItalic { get; set; }
    public IBinding<string> TextValue { get; set; }

    public Text(object? parent = default) : base(parent)
    {
        TextValue = this.CreateBinding(string.Empty);
    }
}