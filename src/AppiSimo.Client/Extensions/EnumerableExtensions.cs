namespace AppiSimo.Client.Extensions
{
    using System;
    using System.Collections;

    public static class EnumerableExtensions
    {
        public static bool Any(this IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();

            try
            {
                return enumerator.MoveNext();
            }
            finally
            {
                (enumerator as IDisposable)?.Dispose();
            }
        }
    }
}