using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

/// <summary>
/// Represents a video associated with a media item, containing metadata about the video, such as its ID, title, release date,
/// associated streams, and additional information like episode/season details or trailers.
/// </summary>
public struct Video
{
    /// <summary>
    /// The unique identifier of the video. This ID is used to reference the video.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The title of the video. This could be the name or description of the video, typically shown to users.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// The release date of the video. This indicates when the video was made available.
    /// </summary>
    [JsonPropertyName("released")]
    public DateTime Released { get; set; }

    /// <summary>
    /// The thumbnail image associated with the video. This is an optional field, which can provide a preview image for the video.
    /// </summary>
    [JsonPropertyName("thumbnail")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Thumbnail { get; set; }

    /// <summary>
    /// A list of streams available for the video. Each stream represents a source or format from which the video can be watched.
    /// These streams are represented by the <see cref="StremioDotNet.Structs.Stream.Stream"/> struct, which contains the URL, subtitle information, 
    /// sources, and behavior hints for each stream.
    /// </summary>
    [JsonPropertyName("streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Stream.Stream> Streams { get; set; }

    /// <summary>
    /// A flag indicating whether the video is available for viewing. This field is optional and may be null if the availability is unknown.
    /// </summary>
    [JsonPropertyName("available")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Available { get; set; }

    /// <summary>
    /// The episode number of the video, if applicable. This is useful for episodic content like TV shows.
    /// </summary>
    [JsonPropertyName("episode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Episode { get; set; }

    /// <summary>
    /// The season number of the video, if applicable. This is used for episodic content like TV shows.
    /// </summary>
    [JsonPropertyName("season")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Season { get; set; }

    /// <summary>
    /// A list of trailers associated with the video. Each trailer is represented by the <see cref="StremioDotNet.Structs.Stream.Stream"/> struct,
    /// containing the stream's URL and associated metadata. This allows for previews or promotional content for the video.
    /// </summary>
    [JsonPropertyName("trailers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Stream.Stream> Trailers { get; set; }

    /// <summary>
    /// An overview or description of the video. This optional field provides additional information about the video’s content.
    /// </summary>
    [JsonPropertyName("overview")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Overview { get; set; }
}