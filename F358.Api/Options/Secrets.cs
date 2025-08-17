using JetBrains.Annotations;

namespace F358.Api.Options;

public class Secrets
{
    public string? UserServiceApiKey { get; [UsedImplicitly] init; }
}