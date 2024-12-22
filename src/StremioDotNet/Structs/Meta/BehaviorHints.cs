using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

public struct BehaviorHints
{
    [JsonPropertyName("defaultVideoId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string DefaultVideoId { get; set; }
}