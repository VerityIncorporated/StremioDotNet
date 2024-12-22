using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

public struct Subtitle
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("lang")]
    public string Lang { get; set; }
}