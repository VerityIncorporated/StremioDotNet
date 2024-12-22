using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

public struct Stream
{
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    [JsonPropertyName("ytId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? YtId { get; set; }

    [JsonPropertyName("infoHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InfoHash { get; set; }

    [JsonPropertyName("fileIdx")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FileIdx { get; set; }

    [JsonPropertyName("externalUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExternalUrl { get; set; }
        
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    [JsonPropertyName("subtitles")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Subtitle>? Subtitles { get; set; }

    [JsonPropertyName("sources")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Sources { get; set; }

    [JsonPropertyName("behaviorHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BehaviorHints? BehaviorHints { get; set; }
}