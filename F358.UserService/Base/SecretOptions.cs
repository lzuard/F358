using JetBrains.Annotations;

namespace F358.UserService.Base;

public class SecretOptions
{
    public const string SectionName = "Keys";
    public string? AuthEncryptionKey { get; [UsedImplicitly] init; }
    public string? JwtKey { get; [UsedImplicitly] init; }
}