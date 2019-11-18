namespace AppiSimo.Client.Tools.InputLocalDatePicker
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using NodaTime;
    using System;

    public class InputLocalDatePicker : ComponentBase
    {
        DateTime? _date;

        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        [Parameter]
        public LocalDate Value
        {
            get => LocalDate.FromDateTime(Date ?? new DateTime());
            set => Date = value == default ? (DateTime?) null : value.ToDateTimeUnspecified();
        }

        [Parameter] public EventCallback<LocalDate> ValueChanged { get; set; }
        [Parameter] public string Class { get; set; }
        
        protected DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                ValueChanged.InvokeAsync(Value);
                CascadedEditContext?.NotifyValidationStateChanged();
            }
        }
    }
}