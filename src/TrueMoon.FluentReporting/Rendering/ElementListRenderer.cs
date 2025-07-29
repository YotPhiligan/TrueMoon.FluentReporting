using TrueMoon.FluentReporting.Elements;

namespace TrueMoon.FluentReporting.Rendering;

public class ElementListRenderer : RendererBase<IElementList>
{
    public override void Render(IRenderContext context, IElementList element)
    {
        if (element.Margin?.Top is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Top());
        }

        var enumerator = element.GetItems();

        var components = element.GetComponents();
        
        if (enumerator != null)
        {
            foreach (var item in enumerator)
            {
                element.DataSource = item;
                foreach (var component in components)
                {
                    var renderer = RendererResolver.Resolve(component);
                
                    renderer.Render(context, component);
                }
            }
        }
        
        if (element.Margin?.Bottom is {})
        {
            context.AdvanceVerticalSpace(element.Margin.Bottom());
        }
    }

}