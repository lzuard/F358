namespace F358.Api.Options;

public interface IServiceOptions
{
    public string? BaseUri { get; set; }
    public int TimeOutSeconds { get; set; }
}