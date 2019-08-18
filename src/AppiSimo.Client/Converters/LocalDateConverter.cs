namespace AppiSimo.Client.Converters
{
    using System.Globalization;
    using AppiSimo.Client.Abstract;
    using NodaTime;
    using NodaTime.Text;

    public class LocalDateConverter : ITypeConverter<LocalDate>
    {
        LocalDatePattern _pattern = LocalDatePattern.CreateWithInvariantCulture("dd:MM:yyyy");

        public string Pattern
        {
            get => _pattern.PatternText;
            set => _pattern = LocalDatePattern.CreateWithInvariantCulture(value);
        }

        public string FormatValueAsString(LocalDate value) =>
            value == new LocalDate()
                ? string.Empty
                : value.ToString(Pattern,
                                 CultureInfo.InvariantCulture);

        public bool TryParseValueFromString(string value, out LocalDate result)
        {
            if (value != string.Empty) return _pattern.Parse(value).TryGetValue(default, out result);

            result = new LocalDate();
            return true;
        }
    }
}