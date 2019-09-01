namespace AppiSimo.Client.Pages.Tools.TableTemplate
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TableTemplateComponent<TItem> : ComponentBase
    {
        [Parameter] public RenderFragment TableHeader { get; set; }

        [Parameter] public RenderFragment<TItem> RowTemplate { get; set; }

        [Parameter] public ICollection<TItem> Items { get; set; }
    }
}