using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StremioDotNet.Attributes;

namespace StremioDotNet.Middleware;

/// <summary>
/// Middleware to resolve IMDb ID metadata for specific requests.
/// This middleware checks if the request is for a stream and if the 
/// ResolveImdbId property is enabled in the StreamHandlerAttribute. 
/// If so, it extracts the IMDb ID from the request path and retrieves 
/// the associated metadata from an external service.
/// </summary>
public class ImdbIdResolutionMiddleware : IMiddleware
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ImdbIdResolutionMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImdbIdResolutionMiddleware"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client used to make requests to the external metadata service.</param>
    /// <param name="logger">The logger used for logging errors and information.</param>
    public ImdbIdResolutionMiddleware(HttpClient httpClient, ILogger<ImdbIdResolutionMiddleware> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Invokes the middleware logic, checking for the presence of a StreamHandlerAttribute
    /// with ResolveImdbId set to true. If so, extracts the IMDb ID from the request path and
    /// fetches the associated metadata from an external service.
    /// </summary>
    /// <param name="context">The HTTP context of the incoming request.</param>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Check if the endpoint has a StreamHandlerAttribute and whether it requests IMDb ID resolution
        var streamAttribute = context.GetEndpoint()?.Metadata
            .OfType<StreamHandlerAttribute>()
            .FirstOrDefault();
            
        // If the attribute requests IMDb ID resolution, attempt to resolve the IMDb ID from the path
        if (streamAttribute is { ResolveImdbId: true })
        {
            var imdbId = ExtractImdbId(context.Request.Path);
                
            if (!string.IsNullOrEmpty(imdbId))
            {
                var metadata = await ResolveImdbIdToMetadataAsync(streamAttribute.Type, imdbId);
                context.Items[imdbId] = metadata; // Store metadata in the context items collection
            }
        }
            
        // Pass control to the next middleware in the pipeline
        await next(context);
    }

    /// <summary>
    /// Resolves the IMDb ID to metadata by making a request to an external metadata service.
    /// </summary>
    /// <param name="type">The type of content (e.g., movie, series).</param>
    /// <param name="imdbId">The IMDb ID to resolve.</param>
    /// <returns>The resolved metadata or null if the request fails.</returns>
    private async Task<dynamic?> ResolveImdbIdToMetadataAsync(string type, string imdbId)
    {
        try
        {
            // Make an HTTP request to the external metadata service
            var response = await _httpClient.GetAsync($"https://v3-cinemeta.strem.io/meta/{type}/{imdbId}.json");
                
            // Ensure a successful response status code
            response.EnsureSuccessStatusCode();
                
            // Read and deserialize the response content
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(responseBody);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to resolve IMDb ID metadata.");
            return null; // Return null if an error occurs
        }
    }

    /// <summary>
    /// Extracts the IMDb ID from the request path.
    /// The IMDb ID is expected to be part of the path structure, located between the last two slashes.
    /// </summary>
    /// <param name="path">The request path.</param>
    /// <returns>The extracted IMDb ID, or an empty string if no valid ID is found.</returns>
    private static string ExtractImdbId(string path)
    {
        path = path.TrimEnd('/');
            
        // Find the last occurrence of a slash and ".json" in the path
        var lastSlashIndex = path.LastIndexOf('/');
        var jsonIndex = path.LastIndexOf(".json", StringComparison.Ordinal);
            
        if (lastSlashIndex > 0 && jsonIndex > lastSlashIndex)
        {
            // Extract the substring between the last slash and ".json"
            return path.Substring(lastSlashIndex + 1, jsonIndex - lastSlashIndex - 1);
        }

        return string.Empty; // Return an empty string if IMDb ID is not found
    }
}