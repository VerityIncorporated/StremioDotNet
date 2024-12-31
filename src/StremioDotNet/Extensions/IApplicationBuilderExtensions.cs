using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using StremioDotNet.Builders;
using StremioDotNet.Middleware;

namespace StremioDotNet.Extensions;

/// <summary>
/// Extension methods for <see cref="IApplicationBuilder"/> to configure a Stremio addon.
/// This allows integration of Stremio addon functionality into an ASP.NET Core application.
/// </summary>
public static class IApplicationBuilderExtensions
{
    /// <summary>
    /// Configures the application to use a Stremio addon, including setting up middleware
    /// and defining the necessary endpoints for the addon.
    /// This method sets up CORS, IMDb ID resolution middleware, and maps a GET endpoint
    /// to serve the addon manifest at "/manifest.json".
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/> instance used to configure the HTTP request pipeline.</param>
    /// <param name="createAddonBuilder">A factory function that creates an <see cref="AddonBuilder"/> instance,
    /// which is used to configure the addon (such as building its manifest).</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="createAddonBuilder"/> is null.</exception>
    public static void UseStremioAddon(this IApplicationBuilder app,
        Func<AddonBuilder> createAddonBuilder)
    {
        // Check that the provided factory function is not null
        ArgumentNullException.ThrowIfNull(createAddonBuilder);
            
        var builder = createAddonBuilder();
            
        // Enable Cross-Origin Resource Sharing (CORS) for "Stremio"
        app.UseCors("Stremio");
            
        // Add the IMDb ID resolution middleware to the pipeline
        app.UseMiddleware<ImdbIdResolutionMiddleware>();
            
        // Define the endpoint for the manifest
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/manifest.json", async context =>
            {
                // Build the addon manifest using the provided AddonBuilder
                var manifest = builder.BuildManifest();
                    
                // Send the manifest as a JSON response
                await context.Response.WriteAsJsonAsync(manifest);
            });
            
            endpoints.MapGet("{config?}/manifest.json", async context =>
            {
                // Build the addon manifest using the provided AddonBuilder
                var manifest = builder.BuildManifest();
                
                // Send the manifest as a JSON response
                await context.Response.WriteAsJsonAsync(manifest);
            });
            
            // Configuration page using Liquid, no longer being worked on since I am not proficient in front-end web development.
            /*endpoints.MapGet("/configure", async context =>
            {
                // Build the manifest object (e.g., app configuration or settings)
                var manifest = builder.BuildManifest();
    
                // Create a FluidParser instance to handle template parsing
                var parser = new FluidParser();

                // Attempt to parse the embedded HTML template for the configuration page
                if (parser.TryParse(GetEmbeddedResource("StremioDotNet.Templates.configuration.liquid"), 
                        out var template, out var error))
                {
                    // Create a TemplateContext with the manifest data to pass to the template
                    var templateContext = new TemplateContext(manifest);
                    templateContext.Options.MemberAccessStrategy.Register<Config>();
                    var renderedHtml = await template.RenderAsync(templateContext);
                    
                    // Set the response content type to "text/html"
                    context.Response.ContentType = "text/html";
    
                    // Write a simple response (could be updated with dynamic HTML content)
                    await context.Response.WriteAsync(renderedHtml);
                }
                else
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync($"Error parsing template: {error ?? "Unknown error"}");
                }
            });*/
        });

        if (!builder.publishToCentral) return;
        
        var httpClient = app.ApplicationServices.GetService(typeof(HttpClient)) as HttpClient;
        AddonPublisher.PublishToCentral(builder.publishToCentralDomain!, httpClient!);
    }

    // Used to get the Liquid resource, no longer being worked on since I am not proficient in front-end web development.
    /*static string GetEmbeddedResource(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        using var stream = assembly.GetManifestResourceStream(resourceName);
        
        if (stream == null)
        {
            throw new FileNotFoundException($"Resource '{resourceName}' not found.");
        }

        using var reader = new StreamReader(stream);
        
        return reader.ReadToEnd();
    }*/
}