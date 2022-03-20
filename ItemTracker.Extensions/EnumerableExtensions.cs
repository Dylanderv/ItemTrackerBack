namespace ItemTracker.Extensions
{
    public static class EnumerableExtensions
    {
        public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(this IEnumerable<T> elements, Func<T, Task<TResult>> func)
        {
            return await elements.Select(func).PipeAsync(Task.WhenAll);
        }

        public static async Task<List<T>> ToListAsync<T>(this Task<IEnumerable<T>> element)
        {
            return (await element).ToList();
        }
    }
}
