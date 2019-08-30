using NodaTime;

namespace AppiSimo.Client.Pages.Tools.InputSelectLocalTime
{
    using System.Collections.Generic;
    using AppiSimo.Client.Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using NodaTime;

    public class InputSelectLocalTime : ComponentBase
    {
        [Inject] protected ITypeConverter<LocalTime> Converter { get; set; }
        
        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        [Parameter] protected IEnumerable<LocalTime> Items { get; set; }

        [Parameter] protected LocalTime Value { get; set; }

        [Parameter] EventCallback<LocalTime> ValueChanged { get; set; }

        protected string Time
        {
            get => Converter.FormatValueAsString(Value);
            set
            {
                Converter.TryParseValueFromString(value, out var result);
                Value = result;
                ValueChanged.InvokeAsync(Value);
                CascadedEditContext?.NotifyValidationStateChanged();
            }
        }
    }
}