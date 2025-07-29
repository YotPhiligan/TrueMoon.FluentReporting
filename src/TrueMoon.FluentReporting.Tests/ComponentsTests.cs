using TrueMoon.FluentReporting.Elements;
using TrueMoon.FluentReporting.Exporters;

namespace TrueMoon.FluentReporting.Tests;

public class ComponentsTests
{
    private static IReport<TestData2> GetTemplate()
    {
        var template = Report.Create<TestData2>(template => template
            .PageMargin(left:50, top:20, right:50, bottom:50)
            .Page(page => page
                .Title(title => title.Text("Test Report").HorizontalAlignment(HorizontalAlignment.Center))
                .Text("List of tables")
                .List(data => data.List2, list => list
                    .Table(table => table
                        .WithSource(data => data)
                        .Column(column => column
                            .Alignment(horizontalAlignment:HorizontalAlignment.Left,verticalAlignment:VerticalAlignment.Bottom)
                            .Header("KeyHeader")
                            .Value(data => data.key)
                            .Width("1*")
                        )
                        .Column(column => column
                            .Alignment(horizontalAlignment:HorizontalAlignment.Right)
                            .Header("ValueHeader1")
                            .Value(data => data.value)
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
                    .BlankSpace(3f)
                )
                .BlankSpace(4f)
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
                    .As<IText<TestData2>>()
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
        var data = GetTestData();
        var template = GetTemplate();
        template.DataSource = data;
        
        template.ExportPdf(Path.Combine(AppContext.BaseDirectory, "test1.pdf"));
        
        Assert.NotNull(template);
    }
    
    [Fact]
    public void Template2()
    {
        var template = Report.Create<TestData>(template => template
            .PageMargin(left:50, top:20, right:50, bottom:50)
            .Page(page => page
                .Title(title => title.Text("Data Report").HorizontalAlignment(HorizontalAlignment.Center))
                .Text("Some text")
                .BlankSpace(4f)
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
                .Text("some text 1")
                .Text(t=>t
                    .Text("some text 2")
                    .Visibility(false)
                )
                .Text(t=>t
                    .Text("some text 3")
                    .Visibility(data => data == null)
                    .As<IText<TestData2>>()
                )
                .BlankSpace(20)
                .Image(image => image.LoadFrom(data=>data.ImageData))
            )
        );
        
        Assert.NotNull(template);
    }
    
    private static TestData2 GetTestData()
    {
        return new TestData2
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
            List2 = [[("key1", "value1"),
                ("key2", "value2"),
                ("key3", "value3")],
                [("key11", "value1"),
                    ("key22", "value2")]],
            ImageData = File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "image.jpg"))
        };
    }
}