using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

public struct MetaLink
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}