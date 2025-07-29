namespace TrueMoon.FluentReporting;

public interface IHideable
{
    bool? IsVisible { get; }
    IBinding<bool?> Visibility { get; set; }
}