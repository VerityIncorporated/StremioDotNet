using Microsoft.AspNetCore.Mvc.Routing;

namespace StremioDotNet.Attributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class MetaHandlerAttribute()
    : HttpMethodAttribute(["GET"], $"meta/{{type}}/{{id}}.json");