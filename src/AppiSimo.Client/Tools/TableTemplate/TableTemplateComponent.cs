namespace AppiSimo.Client.Tools.TableTemplate
{
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;

    public class TableTemplateComponent<TItem> : ComponentBase
    {
        [Parameter] public RenderFragment TableHeader { get; set; }
        [Parameter] public RenderFragment<TItem> RowTemplate { get; set; }
        [Parameter] public ICollection<TItem> Items { get; set; }
    }
}