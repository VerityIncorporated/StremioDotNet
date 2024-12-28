using Microsoft.AspNetCore.Mvc.Routing;

namespace StremioDotNet.Attributes;

/// <summary>
/// Custom attribute used to mark methods that handle stream requests in a Stremio service.
/// This attribute maps a method to a specific HTTP GET request pattern for retrieving stream information
/// based on the type and ID provided in the URL.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class StreamHandlerAttribute : HttpMethodAttribute
{
    /// <summary>
    /// Gets the type of the stream (e.g., "movie", "series").
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Gets a flag indicating whether to resolve IMDb ID during the stream lookup.
    /// When set to true, this flag will trigger the middleware to fetch and fill the metadata
    /// of the requested stream (show or movie) based on its IMDb ID, which will be added to the request's 
    /// items collection for further use.
    /// </summary>
    public bool ResolveImdbId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StreamHandlerAttribute"/> class.
    /// This attribute binds the decorated method to a GET request for retrieving stream data.
    /// The URL pattern follows the format "stream/{type}/{id}.json", where {type} and {id} are dynamic parameters.
    /// The <paramref name="type"/> is a required parameter to specify the type of stream (e.g., movie, series),
    /// and <paramref name="resolveImdbId"/> indicates whether to resolve the IMDb ID and fetch additional metadata.
    /// </summary>
    /// <param name="type">The type of the stream, such as "movie" or "series".</param>
    /// <param name="resolveImdbId">A flag indicating whether to resolve the IMDb ID and retrieve associated metadata (defaults to false).</param>
    /// <param name="usingConfig">A flag indicating whether to use the config route for requests.</param>
    public StreamHandlerAttribute(string type, bool resolveImdbId = false, bool usingConfig = false)
        : base(["GET"], usingConfig ? $"{{config}}/stream/{type}/{{id}}/{{extra?}}" : $"stream/{type}/{{id}}/{{extra?}}")
    {
        Type = type;
        ResolveImdbId = resolveImdbId;
    }
}