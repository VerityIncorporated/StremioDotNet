using Microsoft.AspNetCore.Mvc.Routing;

namespace StremioDotNet.Attributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class StreamHandlerAttribute(string type, bool resolveImdbId = false)
    : HttpMethodAttribute(["GET"], $"stream/{type}/{{id}}.json")
{
    public string Type { get; } = type;
    public bool ResolveImdbId { get; } = resolveImdbId;
}