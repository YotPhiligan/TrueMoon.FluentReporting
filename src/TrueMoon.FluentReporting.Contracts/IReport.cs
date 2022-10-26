namespace TrueMoon.FluentReporting;

public interface IReport
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
    void SetDataSource(TData? data);
    void AddPage(Action<IPage<TData>> action);
    TData? Data { get; }
}