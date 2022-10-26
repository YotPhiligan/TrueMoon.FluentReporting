namespace TrueMoon.FluentReporting.Elements;

public class Text<TData> : Element<TData>, IText<TData>
{
    protected Func<TData?,object?>? TextValueDelegate;
    protected string TextValue;

    public virtual void SetTextDelegate(Func<TData?, object?> func)
    {
        ArgumentNullException.ThrowIfNull(func);
        TextValueDelegate = func;
    }

    public string? Font { get; set; }
    public float? FontSize { get; set; }
    public bool? IsBold { get; set; }
    public bool? IsItalic { get; set; }

    public virtual void SetText(string text)
    {
        TextValue = text;
    }

    public virtual string GetText()
    {
        TData? data = Page.Report.Data;
        var value = TextValueDelegate?.Invoke(data) ?? TextValue;
        return $"{value}";
    }

    public Text(IPage<TData> page, IElement? parent = default) : base(page, parent)
    {
    }
}