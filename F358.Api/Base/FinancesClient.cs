using F358.Api.Options;
using F358.Shared.Dto;
using Microsoft.Extensions.Options;

namespace F358.Api.Base;

public class FinancesClient<T>(IOptions<T> options) where T: class, IServiceOptions
{
    private readonly HttpClient _client = options.Value.BaseUri is null
        ? throw new ArgumentNullException(nameof(options.Value.BaseUri))
        : new HttpClient
        {
            BaseAddress = new Uri(options.Value.BaseUri),
            Timeout = TimeSpan.FromSeconds(options.Value.TimeOutSeconds)
        };

    public async Task<ProcessResult?> PostDefaultResultAsync<TRequest>(
        string endpoint,
        TRequest request,
        CancellationToken ct
    ) => await PostCustomResultAsync<ProcessResult, TRequest>(
        endpoint,
        request,
        ct
    );
    
    public async Task<ProcessResultWithData<TData>?> PostDefaultResultWithDataAsync<TRequest, TData>(
        string endpoint,
        TRequest request,
        CancellationToken ct
    ) => await PostCustomResultAsync<ProcessResultWithData<TData>, TRequest>(
        endpoint,
        request,
        ct
    );
    
    public async Task<TResponse?> PostCustomResultAsync<TResponse, TRequest>(
        string endpoint,
        TRequest request,
        CancellationToken ct)
    {
        var response = await _client.PostAsJsonAsync(endpoint, request, ct);
        
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<TResponse>(ct);
    }

    public async Task<TResponse?> GetAsync<TResponse>(Uri uri, CancellationToken ct)
    {
        var response = await _client.GetAsync(uri, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResponse>(ct);
    }
}