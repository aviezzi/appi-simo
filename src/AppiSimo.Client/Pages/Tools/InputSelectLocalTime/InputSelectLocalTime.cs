namespace AppiSimo.Client.Pages.Tools.InputSelectLocalTime
{
    using Abstract;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using NodaTime;
    using System.Collections.Generic;

    public class InputSelectLocalTime : ComponentBase
    {
        [Inject] protected ITypeConverter<LocalTime> Converter { get; set; }

        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        [Parameter] public IEnumerable<LocalTime> Items { get; set; }

        [Parameter] public LocalTime? Value { get; set; }

        [Parameter] public EventCallback<LocalTime> ValueChanged { get; set; }

        [Parameter] public string Class { get; set; }

        protected string Time
        {
            get
            {
                if (Value == null) return string.Empty;

                return Converter.FormatValueAsString(Value.Value);
            }
            set
            {
                if (value == string.Empty)
                {
                    Value = null;
                    return;
                }

                Converter.TryParseValueFromString(value, out var result);
                Value = result;

                ValueChanged.InvokeAsync(Value.Value);
                CascadedEditContext?.NotifyValidationStateChanged();
            }
        }
    }
}