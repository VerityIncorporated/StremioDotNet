using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

public struct ProxyHeaders
{
    [JsonPropertyName("request")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Request { get; set; }

    [JsonPropertyName("response")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Response { get; set; }
}