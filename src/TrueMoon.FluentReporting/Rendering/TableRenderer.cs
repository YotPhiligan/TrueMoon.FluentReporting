using SkiaSharp;
using Topten.RichTextKit;
using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class TableRenderer : RendererBase<ITable>, IRenderer<ITable>
{
    public override void Render(IRenderContext context, ITable element)
    {
        if (element.Margin?.Top is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Top());
        }
        
        var canvas = context.Canvas;
        var columns = element.GetColumns();

        using var linePaint = new SKPaint
        {
            Color = SKColors.Black,
            Style = SKPaintStyle.StrokeAndFill,
            StrokeWidth = 1,
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round,
        };

        CalculateColumns(columns, context.Width, element.Margin);
        
        var top = context.Y;
        
        var width = element.HorizontalAlignment switch {
            HorizontalAlignment.None => context.Width-element.Margin.Left() - element.Margin.Left(),
            HorizontalAlignment.Left => columns.Sum(t => t.Width.ToFloat()),
            HorizontalAlignment.Center => columns.Sum(t => t.Width.ToFloat()),
            HorizontalAlignment.Right => columns.Sum(t => t.Width.ToFloat()),
            HorizontalAlignment.Stretch => context.Width-element.Margin.Left() - element.Margin.Right(),
            null => columns.Sum(t => t.Width.ToFloat()),
            _ => columns.Sum(t => t.Width.ToFloat())
        };
        
        var left = element.HorizontalAlignment switch {
            HorizontalAlignment.None => context.Left+element.Margin.Left(),
            HorizontalAlignment.Left => context.Left+element.Margin.Left(),
            HorizontalAlignment.Center => context.Left + width/2f,
            HorizontalAlignment.Right => context.Right - width,
            HorizontalAlignment.Stretch => context.Left+element.Margin.Left(),
            null => context.Left+element.Margin.Left(),
            _ => context.Left+element.Margin.Left()
        };

        var right = left + width;

        canvas.DrawLine(left, context.Y, right, context.Y, linePaint);
        
        if (element.IsHeaderVisible is true)
        {
            RenderHeader(context, element, columns, left);
            
            canvas.DrawLine(left, context.Y, right, context.Y, linePaint);
        }

        var data = element.GetRecords();

        if (data != null)
        {
            foreach (var o in data)
            {
                RenderRow(context, element, columns, o, left);
                
                canvas.DrawLine(left, context.Y, right, context.Y, linePaint);
            }
        }


        canvas.DrawLine(left, context.Y, right, context.Y, linePaint);

        var columnXOffset = left;
        foreach (var column in columns)
        {
            var columnWidth = column.Width ?? default;
            
            canvas.DrawLine(columnXOffset, top, columnXOffset, context.Y, linePaint);
            columnXOffset += columnWidth;
            canvas.DrawLine(columnXOffset, top, columnXOffset, context.Y, linePaint);
        }
        
        if (element.Margin?.Bottom is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Bottom());
        }
    }

    private static void CalculateColumns(IReadOnlyList<ITableColumn> columns, float width, Margin? componentMargin)
    {
        if (componentMargin != null)
        {
            width = width - (componentMargin.Left ?? default) - (componentMargin.Right ?? default);
        }

        var list = new int?[columns.Count];
        for (var index = 0; index < columns.Count; index++)
        {
            var tableColumn = columns[index];
            if (tableColumn.Width is { })
            {
                continue;
            }

            var value = tableColumn.WidthProportion;
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"Invalid width ({value}) for column - \"{tableColumn.Header}\"");
            }

            if (value.Contains('*'))
            {
                value = value.Trim('*');

                var columnWidth = int.Parse(value);

                list[index] = columnWidth;
            }
        }

        var total = list.Sum();

        for (var index = 0; index < columns.Count; index++)
        {
            var tableColumn = columns[index];
            var w = list[index];
            
            if (tableColumn.Width is null)
            {
                tableColumn.Width = width * (w / (float)total);
            }
        }
    }

    private void RenderRow(IRenderContext context, ITable table, IEnumerable<ITableColumn> columns, object o, float left)
    {
        var list = new List<(ITableColumn column,TextBlock block, float x, SKColor? backColor, float? left, float? width)>();
        
        float rowHeight = table.RowHeight.ToFloat();
        var columnXOffset = left;
        foreach (var column in columns)
        {
            var columnLeft = columnXOffset;
            var columnRight = columnLeft + column.Width.ToFloat();
            var columnCenter = columnRight - column.Width.ToFloat() / 2f;
            
            var rawObject = column.GetValue(o);
            var str = $"{rawObject}";

            var font = column.Font;
            var fontSize = column.FontSize;
            
            
            var tb = new TextBlock();
            
            tb.MaxWidth = column.Width;
            tb.Alignment = column.ContentHorizontalAlignment switch {
                HorizontalAlignment.None => TextAlignment.Center,
                HorizontalAlignment.Left => TextAlignment.Left,
                HorizontalAlignment.Center => TextAlignment.Center,
                HorizontalAlignment.Right => TextAlignment.Right,
                HorizontalAlignment.Stretch => TextAlignment.Auto,
                null => TextAlignment.Center,
                _ => TextAlignment.Center
            }; 
            tb.AddText(str, new Style
            {
                FontFamily = font ?? column.Table.Font ?? "Verdana", 
                FontSize = fontSize ?? column.Table.FontSize ?? 8,
                TextColor = column.GetForeground() is {} foreground 
                    ? (SKColor.TryParse(foreground, out var c1) ? c1 : SKColors.Black) 
                    : SKColors.Black,
                FontWeight = column.IsBold is true ? 600 : 400,
            });

            var cellHeight = tb.MeasuredHeight;
            if (cellHeight > rowHeight)
            {
                rowHeight = cellHeight;
            }

            SKColor? backColor = default;
            if (column.GetBackground(o) is {} background)
            {
                var color = SKColor.TryParse(background, out var c) ? c : SKColor.Empty;

                backColor = color;
            }

            var x = tb.Alignment switch {
                TextAlignment.Auto => columnLeft,
                TextAlignment.Left => columnLeft,
                TextAlignment.Center => columnCenter - column.Width.ToFloat()/2f,
                TextAlignment.Right => columnRight - column.Width.ToFloat(),
                _ => columnCenter
            };

            var item = (column,tb,x, backColor, columnLeft, column.Width);
            list.Add(item);
            
            columnXOffset += column.Width.ToFloat();
        }

        foreach (var item in list)
        {
            if (item.backColor is {} backColor)
            {
                using var skPaint = new SKPaint();
                skPaint.Style = SKPaintStyle.Fill;
                skPaint.Color = backColor;
                context.Canvas.DrawRect(item.left.ToFloat(), context.Y, item.width.ToFloat(), rowHeight, skPaint);
            }

            var itemBlock = item.block;
            var y = item.column.ContentVerticalAlignment switch {
                VerticalAlignment.None => context.Y,
                VerticalAlignment.Top => context.Y,
                VerticalAlignment.Center => context.Y + rowHeight/2f - itemBlock.MeasuredHeight/2f,
                VerticalAlignment.Bottom => context.Y + rowHeight-itemBlock.MeasuredHeight,
                VerticalAlignment.Stretch => context.Y,
                null => context.Y,
                _ => context.Y
            };
            
            itemBlock.Paint(context.Canvas, new SKPoint(item.x, y));
        }
        
        context.AdvanceVerticalSpace(rowHeight);
    }

    private void RenderHeader(IRenderContext context, ITable table, IEnumerable<ITableColumn> columns, float left)
    {
        var list = new List<(ITableColumn column,TextBlock block, float x, SKColor? backColor, float? left, float? width)>();
        float rowHeight = table.HeaderHeight ?? table.RowHeight.ToFloat();
        var columnXOffset = left;
        foreach (var column in columns)
        {
            var columnLeft = columnXOffset;
            var columnRight = columnLeft + column.Width.ToFloat();
            var columnCenter = columnRight - column.Width.ToFloat() / 2f;
            
            var str = $"{column.Header}";

            var font = column.HeaderFont ?? column.Font;
            var fontSize = column.HeaderFontSize ?? column.FontSize;
            
            
            var tb = new TextBlock();
            
            tb.MaxWidth = column.Width;
            tb.Alignment = column.ContentHorizontalAlignment switch {
                HorizontalAlignment.None => TextAlignment.Center,
                HorizontalAlignment.Left => TextAlignment.Left,
                HorizontalAlignment.Center => TextAlignment.Center,
                HorizontalAlignment.Right => TextAlignment.Right,
                HorizontalAlignment.Stretch => TextAlignment.Auto,
                null => TextAlignment.Center,
                _ => TextAlignment.Center
            }; 
            tb.AddText(str, new Style
            {
                FontFamily = font ?? column.Table.Font ?? "Verdana", 
                FontSize = fontSize ?? column.Table.FontSize ?? 8,
                TextColor = column.GetForeground() is {} foreground 
                    ? (SKColor.TryParse(foreground, out var c1) ? c1 : SKColors.Black) 
                    : SKColors.Black,
                FontWeight = (table.IsHeaderFontBold ?? column.IsHeaderFontBold) is true ? 600 : 400,
            });

            var cellHeight = tb.MeasuredHeight;
            if (cellHeight > rowHeight)
            {
                rowHeight = cellHeight;
            }
            
            SKColor? backColor = default;
            if (column.GetBackground() is {} background)
            {
                var color = SKColor.TryParse(background, out var c) ? c : SKColor.Empty;

                backColor = color;
            }

            var x = tb.Alignment switch {
                TextAlignment.Auto => columnLeft,
                TextAlignment.Left => columnLeft,
                TextAlignment.Center => columnCenter - column.Width.ToFloat()/2f,
                TextAlignment.Right => columnRight - column.Width.ToFloat(),
                _ => columnCenter
            };
            
            //tb.Paint(context.Canvas, new SKPoint(x, context.Y));
            var item = (column,tb,x, backColor, columnLeft, column.Width);
            list.Add(item);
            
            columnXOffset += column.Width.ToFloat();
        }
        
        foreach (var item in list)
        {
            if (item.backColor is {} backColor)
            {
                using var skPaint = new SKPaint();
                skPaint.Style = SKPaintStyle.Fill;
                skPaint.Color = backColor;
                context.Canvas.DrawRect(item.left.ToFloat(), context.Y, item.width.ToFloat(), rowHeight, skPaint);
            }

            var itemBlock = item.block;
            var y = item.column.ContentVerticalAlignment switch {
                VerticalAlignment.None => context.Y,
                VerticalAlignment.Top => context.Y,
                VerticalAlignment.Center => context.Y + rowHeight/2f - itemBlock.MeasuredHeight/2f,
                VerticalAlignment.Bottom => context.Y + rowHeight-itemBlock.MeasuredHeight,
                VerticalAlignment.Stretch => context.Y,
                null => context.Y,
                _ => context.Y
            };
            
            itemBlock.Paint(context.Canvas, new SKPoint(item.x, y));
        }
        
        context.AdvanceVerticalSpace(rowHeight);
    }

}