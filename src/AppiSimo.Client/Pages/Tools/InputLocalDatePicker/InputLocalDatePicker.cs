namespace AppiSimo.Client.Pages.Tools.InputLocalDatePicker
{
    using System;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using NodaTime;

    public class InputLocalDatePicker : ComponentBase
    {
        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        [Parameter] public LocalDate? Value { get; set; }

        [Parameter] public EventCallback<LocalDate?> ValueChanged { get; set; }
        
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
    }
}