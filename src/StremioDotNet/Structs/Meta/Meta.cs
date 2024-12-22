using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

/// <summary>
/// Represents metadata information for a media item such as a movie, series, or channel.
/// </summary>
public struct Meta
{
    /// <summary>
    /// The ID of the meta item that is requested.
    /// It is a universal identifier, which may include a prefix unique to your addon, 
    /// such as <c>yt_id:UCrDkAvwZum-UTjHmzDI2iIw</c>.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The type of the media item. Examples include "movie", "series", "channel", "tv", etc.
    /// Refer to Content Types for valid values.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The name of the media item (e.g., the title of the movie or series).
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Optional. A list of genres/categories associated with the media item (e.g., ["Thriller", "Horror"]).
    /// This will soon be deprecated in favor of using links for genre information.
    /// </summary>
    [JsonPropertyName("genres")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Genres { get; set; }

    /// <summary>
    /// Optional. The URL to the poster image of the media item.
    /// Accepted aspect ratios: 1:0.675 (IMDb poster type) or 1:1 (square).
    /// It's recommended to use files under 50KB.
    /// </summary>
    [JsonPropertyName("poster")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Poster { get; set; }

    /// <summary>
    /// Optional. The shape of the poster image. 
    /// It can be "square", "poster" (1:0.675), or "landscape" (1:1.77). If not specified, "poster" is assumed.
    /// </summary>
    [JsonPropertyName("posterShape")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PosterShape { get; set; }

    /// <summary>
    /// Optional. The URL to the background image shown on the Stremio detail page.
    /// It's highly encouraged to provide this for a better visual experience.
    /// Max file size: 500KB.
    /// </summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>
    /// Optional. The URL to the logo image shown on the Stremio detail page.
    /// It's encouraged to provide this for a better visual experience.
    /// </summary>
    [JsonPropertyName("logo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logo { get; set; }

    /// <summary>
    /// Optional. A brief description of the media item.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    
    /// <summary>
    /// Optional. Release information for the media item. For movies, use the year; for series or channels, 
    /// use a start and end year separated by a dash, e.g. "2000-2014", or "2000-" for ongoing content.
    /// </summary>
    [JsonPropertyName("releaseInfo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReleaseInfo { get; set; }

    /// <summary>
    /// Optional. A list of directors involved in the creation of the media item.
    /// This will soon be deprecated in favor of links for director information.
    /// </summary>
    [JsonPropertyName("director")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Director { get; set; }

    /// <summary>
    /// Optional. A list of cast members involved in the media item.
    /// This will soon be deprecated in favor of links for cast information.
    /// </summary>
    [JsonPropertyName("cast")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Cast { get; set; }

    /// <summary>
    /// Optional. The IMDb rating of the media item (a string between 0.0 and 10.0).
    /// </summary>
    [JsonPropertyName("imdbRating")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ImdbRating { get; set; }

    /// <summary>
    /// Optional. The release date of the media item in ISO 8601 format, 
    /// e.g., "2010-12-06T05:00:00.000Z" for the initial cinema debut.
    /// </summary>
    [JsonPropertyName("released")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? Released { get; set; }

    /// <summary>
    /// Optional. A list of trailers associated with the media item, with each trailer containing a source ID and type.
    /// The "type" can be "Trailer" or "Clip".
    /// </summary>
    [JsonPropertyName("trailers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Trailer>? Trailers { get; set; }

    /// <summary>
    /// Optional. A list of internal links related to the media item, 
    /// such as links to actor pages, director pages, etc.
    /// </summary>
    [JsonPropertyName("links")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<MetaLink>? Links { get; set; }

    /// <summary>
    /// Optional. A list of video objects related to the media item, 
    /// e.g., for series or channels. If not provided, Stremio assumes the media item has one video, 
    /// and its ID is equal to the meta item's ID.
    /// </summary>
    [JsonPropertyName("videos")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Video>? Videos { get; set; }

    /// <summary>
    /// Optional. The expected runtime of the media item in a human-readable format (e.g., "120m" for 120 minutes).
    /// </summary>
    [JsonPropertyName("runtime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Runtime { get; set; }

    /// <summary>
    /// Optional. The language in which the media item is spoken.
    /// </summary>
    [JsonPropertyName("language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Language { get; set; }

    /// <summary>
    /// Optional. The official country of origin of the media item.
    /// </summary>
    [JsonPropertyName("country")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Country { get; set; }

    /// <summary>
    /// Optional. A string describing significant awards received by the media item.
    /// </summary>
    [JsonPropertyName("awards")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Awards { get; set; }

    /// <summary>
    /// Optional. The URL to the official website of the media item.
    /// </summary>
    [JsonPropertyName("website")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Website { get; set; }

    /// <summary>
    /// Optional. Behavior hints for the media item, such as a default video ID to open the detail page directly.
    /// </summary>
    [JsonPropertyName("behaviorHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BehaviorHints? BehaviorHints { get; set; }
}