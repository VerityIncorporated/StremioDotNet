using Microsoft.AspNetCore.Mvc.Routing;

namespace StremioDotNet.Attributes;

/// <summary>
/// Custom attribute used to mark methods that handle catalog requests in a Stremio service.
/// This attribute maps a method to a specific HTTP GET request pattern that retrieves catalog information 
/// based on the type and ID provided in the URL.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class CatalogHandlerAttribute : HttpMethodAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogHandlerAttribute"/> class.
    /// This attribute binds the decorated method to a GET request for retrieving catalog data.
    /// The URL pattern follows the format "catalog/{type}/{id}.json", where {type} and {id} are dynamic parameters.
    /// </summary>
    public CatalogHandlerAttribute(Type? configType = null)
        : base(["GET"], configType != null ? "{config}/catalog/{type}/{id}/{extra?}" : "catalog/{type}/{id}/{extra?}")
    {
    }
}