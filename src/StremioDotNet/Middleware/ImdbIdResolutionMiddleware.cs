using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StremioDotNet.Attributes;

namespace StremioDotNet.Middleware;

public class ImdbIdResolutionMiddleware(HttpClient _httpClient, ILogger<ImdbIdResolutionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var streamAttribute = context.GetEndpoint()?.Metadata
            .OfType<StreamHandlerAttribute>()
            .FirstOrDefault();
        
        if (streamAttribute is { ResolveImdbId: true })
        {
            var imdbId = ExtractImdbId(context.Request.Path);
            
            if (!string.IsNullOrEmpty(imdbId))
            {
                var metadata = await ResolveImdbIdToMetadataAsync(streamAttribute.Type, imdbId);
                context.Items[imdbId] = metadata;
            }
        }
        
        await next(context);
    }

    private async Task<dynamic?> ResolveImdbIdToMetadataAsync(string type, string imdbId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://v3-cinemeta.strem.io/meta/{type}/{imdbId}.json");
        
            response.EnsureSuccessStatusCode();
        
            var responseBody = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject(responseBody);
        }
        catch
        {
            return null;
        }
    }
    
    private static string ExtractImdbId(string path)
    {
        path = path.TrimEnd('/');
        
        var lastSlashIndex = path.LastIndexOf('/');
        var jsonIndex = path.LastIndexOf(".json", StringComparison.Ordinal);
        
        if (lastSlashIndex > 0 && jsonIndex > lastSlashIndex)
        {
            return path.Substring(lastSlashIndex + 1, jsonIndex - lastSlashIndex - 1);
        }

        return string.Empty;
    }
}