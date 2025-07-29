using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting;

public interface IReport : IDataSourceProvider
{
    string Author { get; set; }
    DateTime? Creation { get; set; }
    string Creator { get; set; }
    DateTime? Modified { get; set; }
    string Producer { get; set; }
    string Subject { get; set; }
    string Title { get; set; }
    
    float? PageWidth { get; set; }
    float? PageHeight { get; set; }
    
    Margin? PageMargin { get; set; }

    int PagesCount { get; }

    IReadOnlyList<IPage> GetPages();
}

public interface IReport<TData> : IReport
{
    void AddPage(Action<IPage<TData>> action);
    void SetDataSource(TData data);
}