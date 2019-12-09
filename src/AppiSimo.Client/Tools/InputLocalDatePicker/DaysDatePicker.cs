namespace AppiSimo.Client.Tools.InputLocalDatePicker
{
    using MatBlazor;
    using Microsoft.AspNetCore.Components;
    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DaysDatePicker : BaseMatDomComponent
    {
        [Parameter] public IsoDayOfWeek FirstDayOfWeek { get; set; }

        [CascadingParameter(Name = "RenderedValue")]
        protected LocalDate RenderedValue { get; set; }

        [CascadingParameter(Name = "Today")] protected LocalDate Today { get; set; }
        
        protected IEnumerable<IsoDayOfWeek> DaysOfWeek
        {
            get
            {
                for (var day = FirstDayOfWeek; day <= IsoDayOfWeek.Sunday; day++) yield return day;

                for (var day = IsoDayOfWeek.Monday; day < FirstDayOfWeek; day++) yield return day;
            }
        }

        [Parameter] public LocalDate Value { get; set; }
        [Parameter] public EventCallback<LocalDate> ValueChanged { get; set; }
        
        protected void SetDay(LocalDate date)
        {
            Value = date;
            ValueChanged.InvokeAsync(Value);
        }

        protected LocalDate StartDate =>
            RenderedValue.With(DateAdjusters.StartOfMonth).With(DateAdjusters.PreviousOrSame(FirstDayOfWeek));

        protected LocalDate EndDate =>
            RenderedValue.With(DateAdjusters.EndOfMonth).With(DateAdjusters.NextOrSame(DaysOfWeek.Last()));
    }
}