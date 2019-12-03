namespace AppiSimo.Client.Tools.InputLocalDatePicker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MatBlazor;
    using Microsoft.AspNetCore.Components;
    using NodaTime;
    using NodaTime.Extensions;
    using NodaTime.Text;

    public class InputLocalDatePicker : BaseMatInputComponent<LocalDate?>
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Dense { get; set; }

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool FullWidth { get; set; }

        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }

        [Parameter]
        public string HelperText { get; set; }

        [Parameter]
        public LocalDatePattern DateFormat { get; set; } = LocalDatePattern.CreateWithInvariantCulture("dd/MM/yyyy");

        [Parameter]
        public IsoDayOfWeek FirstDayOfWeek { get; set; } = IsoDayOfWeek.Monday;

        protected bool IsOpen { get; set; }

        protected static LocalDate Today => SystemClock.Instance.InZone(DateTimeZoneProviders.Tzdb.GetSystemDefault()).GetCurrentDate();

        protected LocalDate RenderedValue { get; set; }

        protected IEnumerable<IsoDayOfWeek> DaysOfWeek
        {
            get
            {
                var first = IsoDayOfWeek.Monday;
                var last = IsoDayOfWeek.Sunday;

                for (var day = FirstDayOfWeek; day <= last; day++)
                {
                    yield return day;
                }

                for (var day = first; day < FirstDayOfWeek; day++)
                {
                    yield return day;
                }
            }
        }

        protected LocalDate StartDate =>
            RenderedValue.With(DateAdjusters.StartOfMonth).With(DateAdjusters.PreviousOrSame(FirstDayOfWeek));

        protected LocalDate EndDate =>
            RenderedValue.With(DateAdjusters.EndOfMonth).With(DateAdjusters.NextOrSame(DaysOfWeek.Last()));

        protected void SetDate(LocalDate date)
        {
            RenderedValue = date;
            AcceptValue();
        }

        protected void Add(Period period)
        {
            RenderedValue = RenderedValue.Plus(period);
        }

        protected void SetMonth(string monthText)
        {
            var month = int.Parse(monthText);
            try
            {
                RenderedValue = RenderedValue.With(DateAdjusters.Month(month));
            }
            catch (ArgumentOutOfRangeException)
            {
                RenderedValue = new LocalDate(RenderedValue.Year, month, day: 1, RenderedValue.Calendar).With(DateAdjusters.EndOfMonth);
            }
        }

        protected void SetYear(decimal? year)
        {
            if (year == null)
            {
                return;
            }

            try
            {
                RenderedValue = new LocalDate((int) year, RenderedValue.Month, RenderedValue.Day, RenderedValue.Calendar);
            }
            catch (ArgumentOutOfRangeException)
            {
                RenderedValue = new LocalDate((int) year, RenderedValue.Month, 1, RenderedValue.Calendar).With(DateAdjusters.EndOfMonth);
            }
        }

        protected override void OnParametersSet()
        {
            RenderedValue = Value ?? Today;
        }

        void AcceptValue()
        {
            IsOpen = false;
            
            Value = RenderedValue;

            EditContext.NotifyValidationStateChanged();
            ValueChanged.InvokeAsync(Value);
        }
    }
}