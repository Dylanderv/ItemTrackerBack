namespace ItemTracker.Extensions
{
    public static class PipeExtensions
    {
        public static U Pipe<T, U>(this T element, Func<T, U> func)
        {
            return func(element);
        }

        public static async Task<U> PipeAsync<T, U>(this T element, Func<T, Task<U>> func)
        {
            return await func(element);
        }
    }
}
