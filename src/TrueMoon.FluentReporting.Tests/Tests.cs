using TrueMoon.FluentReporting.Elements;
using TrueMoon.FluentReporting.Exporters;

namespace TrueMoon.FluentReporting.Tests;

public class Tests
{
    private static TestData GetTestData()
    {
        return new TestData
        {
            TitleData = "Test Report", 
            TextData = "The quick brown fox jumps over the lazy dog.", 
            List = new List<(string key, string value1, string value2)>
            {
                ("key", "value1", "value2"),
                ("key_1", "value1_1", "value2_1"),
                ("key_2", "value1_2", "value2_2"),
                ("key_3", "value1_3 veeeeeeeeeeeeery long text 2 + The quick brown fox jumps over the lazy dog.", "value2_3 + The quick brown fox jumps over the lazy dog.")
            },
            ImageData = File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "image.jpg"))
        };
    }

    private static IReport<TestData> GetTemplate()
    {
        var template = Report.Create<TestData>(template => template
            .PageMargin(left:50, top:20, right:50, bottom:50)
            .Page(page => page
                .Title(title => title.Text(data => data.TitleData).Font("Arial", 18, isBold:true).Margin(top:20, bottom:40).Alignment(horizontalAlignment:HorizontalAlignment.Center))
                .Line(line => line.Size(height:2).Margin(top:10, bottom:10, left:10, right:10).Foreground("#77aaff"))
                .Title(title => title.Text(data => data.TitleData + " 1").Font("Arial", 18).Alignment(horizontalAlignment:HorizontalAlignment.Left))
                .Title(title => title.Text(data => data.TitleData + " 2").Font("Tahoma", 16).Alignment(horizontalAlignment:HorizontalAlignment.Center).Foreground("#ff852b"))
                .Title(title => title.Text(data => data.TitleData + " 3").Font("Verdana", 14).Alignment(horizontalAlignment:HorizontalAlignment.Right))
                .Text(textContext => textContext.Text(data => data.TextData))
                .Table(table => table
                    .WithSource(data => data.List)
                    .Column(column => column
                        .Alignment(horizontalAlignment:HorizontalAlignment.Left,verticalAlignment:VerticalAlignment.Bottom)
                        .Header("Key")
                        .Value(data => data.key)
                        .Width("1*")
                    )
                    .Column(column => column
                        .Alignment(horizontalAlignment:HorizontalAlignment.Center, verticalAlignment:VerticalAlignment.Center)
                        .Header("Value1")
                        .Value(data => data.value1)
                        .Width("1*")
                    )
                    .Column(column => column
                        .Alignment(horizontalAlignment:HorizontalAlignment.Right)
                        .Header("Value2")
                        .Value(data => data.value2)
                        .Width("1*")
                        .Background(data => data.key switch
                        {
                            "key" => "#50c878",
                            "key_1" => "#ff852b",
                            "key_2" => "#77aaff",
                            _ => string.Empty
                        })
                    )
                )
                .Image(image => image.LoadFrom(data=>data.ImageData).Size(100, 100).Margin(top:20))
                .Image(image => image.LoadFrom(data=>data.ImageData).Size(100, 100).Margin(top:20).Alignment(horizontalAlignment:HorizontalAlignment.Center))
                .Image(image => image.LoadFrom(data=>data.ImageData).Size(100, 100).Margin(top:20).Alignment(horizontalAlignment:HorizontalAlignment.Right))
            )
            .Page(page => page
                .Table(table => table
                    .WithSource(data => data.List)
                    .Column(column => column
                        .Alignment(horizontalAlignment:HorizontalAlignment.Left,verticalAlignment:VerticalAlignment.Bottom)
                        .Header("Key")
                        .Value(data => data.key)
                        .Width("1*")
                    )
                    .Column(column => column
                        .Alignment(horizontalAlignment:HorizontalAlignment.Right)
                        .Header("Value2")
                        .Value(data => data.value2)
                        .Width("1*")
                        .Background(data => data.key switch
                        {
                            "key" => "#50c878",
                            "key_1" => "#ff852b",
                            "key_2" => "#77aaff",
                            _ => string.Empty
                        })
                    )
                )
                .Text("test text 1")
                .Text(t=>t
                    .Text("test text 2")
                    .Visibility(false)
                )
                .Text("test text 3")
                .Text(t=>t
                    .Text("test text 4")
                    .Visibility(data => data == null)
                    .As<IText<TestData>>()
                )
                .BlankSpace(100)
                .Text("test text 5")
                .Text("test text 6")
                .BlankSpace(50)
                .Image(image => image.LoadFrom(data=>data.ImageData))
            )
        );

        return template;
    }
    
    [Fact]
    public void Template()
    {
        var template = GetTemplate();
        
        Assert.NotNull(template);
    }
    
    [Fact]
    public void PdfExport()
    {
        var data = GetTestData();
        var report = GetTemplate();
        
        report.SetDataSource(data);

        using var fs = File.OpenWrite(Path.Combine(AppContext.BaseDirectory, "test.pdf"));
        report.ExportPdf(fs);
    }
}