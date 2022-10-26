namespace TrueMoon.FluentReporting;

public class FluentReport<TData> : IReport<TData>
{
    private readonly List<IPage<TData>> _pages = new ();
    private TData? _data;

    public void SetDataSource(TData data)
    {
        _data = data;
    }

    public Margin? PageMargin { get; set; }
    public int PagesCount => _pages.Count;
    public IReadOnlyList<IPage> GetPages() => _pages;

    public void AddPage(Action<IPage<TData>> action)
    {
        var page = new Page<TData>(this);
        page.Width = PageWidth;
        page.Height = PageHeight;
        page.Margin = PageMargin;

        action(page);
        page.PageNumber = _pages.Count + 1;

        _pages.Add(page);
    }

    public TData? Data => _data;

    public string Author { get; set; }
    public DateTime? Creation { get; set; }
    public string Creator { get; set; }
    public DateTime? Modified { get; set; }
    public string Producer { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public float? PageWidth { get; set; } = 600;
    public float? PageHeight { get; set; } = 800;
}