using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// A catalog is a collection of content, e.g., a list of movies, series, channels, etc.
/// </summary>
public struct Catalog
{
    /// <summary>
    /// The type of the catalog's content, e.g., "movie", "series", "channel", "tv", etc.
    /// This value determines the kind of media or content the catalog contains and is typically used to filter or classify entries.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the catalog.
    /// Can be any unique string describing the catalog (unique per addon, as an addon can have multiple catalogs). 
    /// For example: if the catalog's name is "Favorite YouTube Videos", the ID could be "fav_youtube_videos".
    /// The ID is essential for differentiating between catalogs in scenarios where an addon provides multiple collections of content.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The human-readable name of the catalog.
    /// This name is used in user-facing interfaces, such as UI menus, to provide context about the catalog's content.
    /// Examples include "Top Movies," "Trending TV Shows," or "Live Channels."
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Additional properties of the catalog.
    /// The <c>Extra</c> field can be used to specify extra filters or options applicable to the catalog.
    /// For example, a movie catalog may support additional filters like "genre," "year," or "language."
    /// This field is optional and can be <c>null</c> if no extra options are needed.
    /// </summary>
    [JsonPropertyName("extra")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extra[]? Extra { get; set; }
}