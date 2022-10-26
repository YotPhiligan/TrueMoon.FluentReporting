namespace TrueMoon.FluentReporting.Elements;

public interface ITitle : IText
{
    
}

public interface ITitle<TData> : ITitle, IText<TData>
{

}