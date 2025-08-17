namespace F358.Api.Options;

public class UserServiceOptions : IServiceOptions
{
    public string? BaseUri { get; set; }
    public int TimeOutSeconds { get; set; }

    public string? EndpointRegister { get; set; }
    public string? EndpointLogin { get; set; }
}