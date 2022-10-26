namespace TrueMoon.FluentReporting;

public interface IHideable
{
    bool? GetVisibility();
    void SetVisibility(bool value);
    void SetVisibilityDelegate(Func<bool?> func);
}

public interface IHideable<TData> : IHideable
{
    void SetVisibilityDelegate(Func<TData, bool?> func);
}