namespace F358.Services.User.Base;

public class LoginOptions
{
    public const string SectionName = "Login";

    public TimeSpan TokenLifeTime { get; init; }
    public int LoginDelayMinMs { get; init; }
    public int LoginDelayMaxMs { get; init; }
}