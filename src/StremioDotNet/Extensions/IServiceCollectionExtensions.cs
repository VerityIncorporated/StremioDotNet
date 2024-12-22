using Microsoft.Extensions.DependencyInjection;
using StremioDotNet.Middleware;

namespace StremioDotNet.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to configure services related to Stremio functionality.
/// This class sets up necessary services for middleware and HTTP client management.
/// </summary>
public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Registers services required for a Stremio addon, including CORS configuration,
    /// an HTTP client, and IMDb ID resolution middleware.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the services are added.</param>
    public static void AddStremio(this IServiceCollection services)
    {
        // Configure CORS to allow specific origins related to Stremio
        services.AddCors(options =>
        {
            options.AddPolicy("Stremio", policyBuilder =>
            {
                policyBuilder
                    .AllowAnyHeader()  // Allow any headers in requests
                    .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
                    .AllowCredentials()  // Allow credentials (cookies, HTTP authentication)
                    .SetIsOriginAllowed(origin =>
                        // Allow origins related to Stremio domains
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
            
        // Add HTTP client service to be used throughout the application
        services.AddHttpClient();
            
        // Register IMDb ID resolution middleware to be used in the request pipeline
        services.AddScoped<ImdbIdResolutionMiddleware>();
    }
}