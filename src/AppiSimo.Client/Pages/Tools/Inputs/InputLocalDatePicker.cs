namespace AppiSimo.Client.Pages.Tools.Inputs
{
    using System;
    using AppiSimo.Client.Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using NodaTime;

    public class InputLocalDatePicker : ComponentBase
    {
        [CascadingParameter]
        protected EditContext CascadedEditContext { get; set; }

        protected DateTime? Date
        {
            get => Value?.ToDateTimeUnspecified();
            set
            {
                Value = value.HasValue ? (LocalDate?) LocalDate.FromDateTime(value.Value) : null;
                ValueChanged.InvokeAsync(Value);
                CascadedEditContext?.NotifyValidationStateChanged();
            }
        }

        [Parameter]
        public LocalDate? Value { get; set; }
        
        [Parameter]
        public EventCallback<LocalDate?> ValueChanged { get; set; }
    }
}