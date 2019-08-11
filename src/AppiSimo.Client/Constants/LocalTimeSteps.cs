using System.Collections.Generic;
using NodaTime;

namespace AppiSimo.Client.Constants
{
    public static class LocalTimeSteps
    {
        public static IEnumerable<LocalTime> FromMidnight { get; } = GetStepsFromMidnight();
        public static IEnumerable<LocalTime> ToMidnight { get; } = GetStepsToMidnight();

        static IEnumerable<LocalTime> GetStepsFromMidnight()
        {
            var step = LocalTime.Midnight;

            do
            {
                yield return step;
                step = step.PlusMinutes(30);
            } while (step != LocalTime.Midnight);
        }

        static IEnumerable<LocalTime> GetStepsToMidnight()
        {
            var step = LocalTime.Midnight.PlusMinutes(30);

            do
            {
                yield return step;
                step = step.PlusMinutes(30);
            } while (step != LocalTime.Midnight);

            yield return LocalTime.MaxValue;
        }
    }
}