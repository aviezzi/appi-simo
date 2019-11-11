namespace AppiSimo.Client.Abstract
{
    using Model;

    public interface ITypeConverter<T>
    {
        string Pattern { get; set; }
        string FormatValueAsString(T value);
        bool TryParseValueFromString(string value, out T result);
    }
}