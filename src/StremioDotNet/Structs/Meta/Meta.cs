using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

public struct Meta
{
    /// <summary>
    /// The ID of the meta item that is requested.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The type of the item, e.g. "movie", "series", "channel", "tv", etc.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("genres")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Genres { get; set; }

    [JsonPropertyName("poster")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Poster { get; set; }

    [JsonPropertyName("posterShape")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PosterShape { get; set; }

    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    [JsonPropertyName("logo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logo { get; set; }

    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    
    [JsonPropertyName("releaseInfo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReleaseInfo { get; set; }

    [JsonPropertyName("director")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Director { get; set; }

    [JsonPropertyName("cast")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Cast { get; set; }

    [JsonPropertyName("imdbRating")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ImdbRating { get; set; }

    [JsonPropertyName("released")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? Released { get; set; }

    [JsonPropertyName("trailers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Trailer>? Trailers { get; set; }

    [JsonPropertyName("links")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<MetaLink>? Links { get; set; }

    [JsonPropertyName("videos")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Video>? Videos { get; set; }

    [JsonPropertyName("runtime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Runtime { get; set; }

    [JsonPropertyName("language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Language { get; set; }

    [JsonPropertyName("country")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Country { get; set; }

    [JsonPropertyName("awards")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Awards { get; set; }

    [JsonPropertyName("website")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Website { get; set; }

    [JsonPropertyName("behaviorHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MetaBehaviorHints? BehaviorHints { get; set; }
}