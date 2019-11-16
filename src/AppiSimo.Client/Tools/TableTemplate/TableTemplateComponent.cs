namespace AppiSimo.Client.Tools.TableTemplate
{
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;

    public class TableTemplateComponent<TItem> : ComponentBase
    {
        [CascadingParameter(Name = "Value")] protected IEnumerable<TItem> Items { get; set; }

        [Parameter] public RenderFragment TableHeader { get; set; }
        [Parameter] public RenderFragment<TItem> RowTemplate { get; set; }
    }
}