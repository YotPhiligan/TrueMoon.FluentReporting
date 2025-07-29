namespace TrueMoon.FluentReporting;

public interface IBinding
{
    object? GetRawValue();
}

public interface IBinding<TValue> : IBinding
{
    TValue? Value { get; }
}