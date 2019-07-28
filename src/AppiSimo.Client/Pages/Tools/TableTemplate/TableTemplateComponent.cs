namespace AppiSimo.Client.Pages.Tools.TableTemplate
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TableTemplateComponent<TItem> : ComponentBase
    {
        [Parameter]
        protected RenderFragment TableHeader { get; set; }
    
        [Parameter]
        protected RenderFragment<TItem> RowTemplate { get; set; }
    
        [Parameter]
        protected ICollection<TItem> Items { get; set; }
    }
}