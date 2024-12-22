using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

public struct MetaBehaviorHints
{
    [JsonPropertyName("defaultVideoId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string DefaultVideoId { get; set; }
}