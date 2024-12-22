using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// A catalog is a collection of content, e.g. a list of movies, series, channels, etc.
/// </summary>
public struct Catalog
{
    /// <summary>
    /// The type of the catalog's content, e.g. "movie", "series", "channel", "tv", etc.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the catalog. Can be any unique string describing the catalog (unique per addon, as an addon can have multiple catalogs). For example: if the catalog's name is "Favorite YouTube Videos", the ID could be "fav_youtube_videos".
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The human-readable name of the catalog
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Additional properties of the catalog
    /// </summary>
    [JsonPropertyName("extra")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extra[]? Extra { get; set; }
}