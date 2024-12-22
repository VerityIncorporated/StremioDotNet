using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

/// <summary>
/// Represents a trailer associated with a media item.
/// The trailer contains information about the video source and its type (e.g., trailer, clip).
/// </summary>
public struct Trailer
{
    /// <summary>
    /// The source of the trailer. This is typically a URL or an ID that points to the video resource.
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; set; }

    /// <summary>
    /// The type of the trailer. It can be "Trailer" for a full trailer, or "Clip" for a short clip of the media item.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
}