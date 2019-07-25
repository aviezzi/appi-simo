namespace AppiSimo.Client.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string value)
            => char.ToLowerInvariant(value[index: 0]) + value.Substring(startIndex: 1);
    }
}