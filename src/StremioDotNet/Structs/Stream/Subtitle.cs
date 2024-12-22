using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

/// <summary>
/// Represents a subtitle for a stream, including its ID, URL, and language.
/// </summary>
public struct Subtitle
{
    /// <summary>
    /// The unique identifier for the subtitle.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The URL where the subtitle file can be accessed.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// The language of the subtitle.
    /// </summary>
    [JsonPropertyName("lang")]
    public string Lang { get; set; }
}