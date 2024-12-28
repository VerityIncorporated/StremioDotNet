using Microsoft.AspNetCore.Mvc.Routing;

namespace StremioDotNet.Attributes;

/// <summary>
/// Custom attribute used to mark methods that handle metadata requests in a Stremio service.
/// This attribute maps a method to a specific HTTP GET request pattern that retrieves metadata 
/// based on the type and ID provided in the URL.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class MetaHandlerAttribute : HttpMethodAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetaHandlerAttribute"/> class.
    /// This attribute binds the decorated method to a GET request for retrieving metadata.
    /// The URL pattern follows the format "meta/{type}/{id}.json", where {type} and {id} are dynamic parameters.
    /// </summary>
    public MetaHandlerAttribute(bool usingConfig = false)
        : base(["GET"], usingConfig ? "{config}/meta/{type}/{id}/{extra?}" : "meta/{type}/{id}/{extra?}" )
    {
    }
}