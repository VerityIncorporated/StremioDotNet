using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using StremioDotNet.Builders;
using StremioDotNet.Middleware;

namespace StremioDotNet.Extensions;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder UseStremioAddon(
        this IApplicationBuilder app,
        Func<AddonBuilder> createAddonBuilder)
    {
        ArgumentNullException.ThrowIfNull(createAddonBuilder);

        app.UseCors("Stremio");
        
        app.UseMiddleware<ImdbIdResolutionMiddleware>();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/manifest.json", async context =>
            {
                var builder = createAddonBuilder();
                var manifest = builder.BuildManifest();
                    
                await context.Response.WriteAsJsonAsync(manifest);
            });
        });

        return app;
    }
}