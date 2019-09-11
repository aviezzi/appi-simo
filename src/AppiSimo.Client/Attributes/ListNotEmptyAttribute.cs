namespace AppiSimo.Client.Attributes
{
    using System;
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using AppiSimo.Client.Extensions;

    [AttributeUsage(AttributeTargets.Property)]
    public class ListNotEmptyAttribute : ValidationAttribute
    {
        public ListNotEmptyAttribute()
            : base(() => "Not allowed empty list.")
        {
        }

        public override bool IsValid(object value) =>
            value switch
            {
                null => false,
                ICollection collection => collection.Count > 0,
                IEnumerable enumerable => enumerable.Any(),
                _ => throw new NotSupportedException($"This attribute can only validate collections but was used for '{value.GetType()}'.")
            };
    }
}