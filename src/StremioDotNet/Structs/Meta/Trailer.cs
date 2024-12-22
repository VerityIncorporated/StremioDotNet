using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

public struct Trailer
{
    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}