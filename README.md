# TrueMoon.FluentReporting

Small and lightweight reporting framework with fluent API

Basic sample:

```C#
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

template.ExportPdf(Path.Combine(AppContext.BaseDirectory, "report.pdf"));

```