using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

/// <summary>
/// Represents optional behavior flags for metadata configuration.
/// </summary>
public struct BehaviorHints
{
    /// <summary>
    /// Gets or sets the default video ID to be used for opening the Detail page directly to that video's streams.
    /// </summary>
    /// <remarks>
    /// This property is optional. If specified, it should be set to the ID of a Video Object.
    /// When provided, the application may use this ID to bypass intermediate steps and display
    /// the streams associated with the specified video directly.
    /// </remarks>
    [JsonPropertyName("defaultVideoId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string DefaultVideoId { get; set; }
}