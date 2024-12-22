using Microsoft.Extensions.DependencyInjection;
using StremioDotNet.Middleware;

namespace StremioDotNet.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddStremio(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Stremio", policyBuilder =>
            {
                policyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin =>
                        origin.Contains(".strem.io") ||
                        origin.Contains(".stremio.net") ||
                        origin.Contains(".stremio.com") ||
                        origin.Contains("stremio-development.netlify.app") ||
                        origin.Contains("stremio.github.io") ||
                        origin.Contains("gstatic.com") ||
                        origin == "https://stremio.github.io" ||
                        origin.Contains("127.0.0.1:11470") ||
                        origin.Contains("localhost:11470")
                    );
            });
        });
        
        services.AddHttpClient();
        services.AddScoped<ImdbIdResolutionMiddleware>();
    }
}