namespace AppiSimo.Client.Tools.InputLocalDatePicker
{
    using MatBlazor;
    using Microsoft.AspNetCore.Components;
    using NodaTime;

    public class MonthsDatePicker : BaseMatDomComponent
    {
        [Parameter] public int Value { get; set; }
        [Parameter] public EventCallback<int> ValueChanged { get; set; }
        
        protected void SetValue(int date)
        {
            Value = date;
            ValueChanged.InvokeAsync(Value);
        }
    }
}