using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

/// <summary>
/// Represents a metadata link associated with a media item.
/// A MetaLink contains information about a related link, such as its name, category, and URL.
/// </summary>
public struct MetaLink
{
    /// <summary>
    /// The name of the link. This is usually a short descriptive name of the related link, such as "Official Website" or "IMDb".
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The category of the link, indicating its type or purpose. Examples could include "Website", "Streaming", "IMDb", etc.
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; }

    /// <summary>
    /// The URL of the link. This is the actual web address pointing to the related content, such as the media's website or a streaming service.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}