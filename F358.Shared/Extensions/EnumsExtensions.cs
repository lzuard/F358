namespace F358.Shared.Extensions;

public static class EnumsExtensions
{
    public static string GetString<T>(this T value) where T : Enum =>
        Enum.GetName(typeof(T), value) ?? throw new ArgumentException("Could not get name from enum");
}