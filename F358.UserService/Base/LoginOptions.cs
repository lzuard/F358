namespace F358.UserService.Base;

public class LoginOptions
{
    public const string SectionName = "Login";

    public TimeSpan TokenLifeTime { get; init; }
    public int LoginDelayMinMs { get; init; }
    public int LoginDelayMaxMs { get; init; }
}