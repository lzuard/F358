namespace F358.Shared.Extensions;

public static class LinqExtensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }
    
    public static IEnumerable<T> ForEachYield<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
            yield return item;
        }
    }

    public static void AddOrInitAndAdd<T>(ref ICollection<T>?source, T item)
    {
        source ??= [];
        source.Add(item);
    }
}