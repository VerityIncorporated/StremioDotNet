using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

/// <summary>
/// Represents optional behavior flags and hints for how a stream should behave in specific contexts.
/// </summary>
public struct BehaviorHints
{
    /// <summary>
    /// Specifies a list of countries (ISO 3166-1 alpha-3 codes) where the stream is available.
    /// </summary>
    [JsonPropertyName("countryWhitelist")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? CountryWhitelist { get; set; }

    /// <summary>
    /// Flag indicating that the stream is not web-ready. This is useful when the URL does not support HTTPS or the stream
    /// is not an MP4 file.
    /// </summary>
    [JsonPropertyName("notWebReady")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NotWebReady { get; set; }

    /// <summary>
    /// A group label for streams that should be grouped together for binge watching (e.g., "gobsAddon-720p").
    /// </summary>
    [JsonPropertyName("bingeGroup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BingeGroup { get; set; }

    /// <summary>
    /// Proxy headers for the stream, used when <see cref="NotWebReady"/> is set to true. This includes headers that should
    /// be used for the stream (e.g., User-Agent).
    /// </summary>
    [JsonPropertyName("proxyHeaders")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ProxyHeaders? ProxyHeaders { get; set; }

    /// <summary>
    /// The calculated OpenSubtitles hash for the video. This is used when the streaming server is not connected and cannot
    /// calculate the hash locally.
    /// </summary>
    [JsonPropertyName("videoHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VideoHash { get; set; }

    /// <summary>
    /// The size of the video file in bytes. This value is passed to subtitle addons to identify correct subtitles.
    /// </summary>
    [JsonPropertyName("videoSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? VideoSize { get; set; }

    /// <summary>
    /// The filename of the video file. It is recommended to set this value when using <see cref="Url"/> to help identify
    /// the correct subtitles.
    /// </summary>
    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Filename { get; set; }
}