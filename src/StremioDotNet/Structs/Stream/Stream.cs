using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

/// <summary>
/// Represents a stream of a video, providing metadata about the source, format, and behavior of the video stream.
/// This struct is used to define the stream, either from a URL, YouTube, or torrent source, and includes various properties
/// such as subtitles, quality, and additional behavior flags for the stream.
/// </summary>
public struct Stream
{
    /// <summary>
    /// The direct URL to a video stream. It must be an MP4 over HTTPS. Other video formats over HTTP/RTMP are supported
    /// if the <see cref="BehaviorHints.NotWebReady"/> is set to true.
    /// </summary>
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    /// <summary>
    /// The YouTube video ID, used to play the stream using the built-in YouTube player.
    /// </summary>
    [JsonPropertyName("ytId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? YtId { get; set; }

    /// <summary>
    /// The info hash of a torrent file. The <see cref="FileIdx"/> represents the index of the video file within the torrent.
    /// If <see cref="FileIdx"/> is not specified, the largest file in the torrent will be selected.
    /// </summary>
    [JsonPropertyName("infoHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InfoHash { get; set; }

    /// <summary>
    /// The index of the video file within the torrent (from <see cref="InfoHash"/>). If not specified, the largest file is selected.
    /// </summary>
    [JsonPropertyName("fileIdx")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FileIdx { get; set; }

    /// <summary>
    /// An external URL or Meta Link to the video, which should be opened in a browser (e.g., a link to Netflix or other external websites).
    /// </summary>
    [JsonPropertyName("externalUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExternalUrl { get; set; }

    /// <summary>
    /// The name of the stream, typically used for stream quality (e.g., "1080p", "720p"). This is an optional field.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    /// A description of the stream (deprecated in favor of <see cref="Description"/>).
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    /// A description of the stream. This field provides additional information about the stream and is the preferred description field.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    /// A list of subtitle objects for this stream. Each subtitle represents a language or track available for the video.
    /// </summary>
    [JsonPropertyName("subtitles")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Subtitle>? Subtitles { get; set; }

    /// <summary>
    /// A list of additional sources for this stream, such as torrent tracker URLs or DHT network nodes. This can be used
    /// for additional peer discovery options when <see cref="InfoHash"/> is specified.
    /// </summary>
    [JsonPropertyName("sources")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Sources { get; set; }

    /// <summary>
    /// Behavior hints for the stream, providing flags that alter how the stream behaves.
    /// </summary>
    [JsonPropertyName("behaviorHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BehaviorHints? BehaviorHints { get; set; }
}