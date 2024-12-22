using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

/// <summary>
/// Represents the proxy headers that can be used when the stream is not web-ready.
/// These headers are applied to the request and response when interacting with a stream URL.
/// </summary>
public struct ProxyHeaders
{
    /// <summary>
    /// A dictionary of headers to be sent with the request when accessing the stream.
    /// This can be used to add custom headers like "User-Agent" or any other headers required for the request.
    /// </summary>
    [JsonPropertyName("request")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Request { get; set; }

    /// <summary>
    /// A dictionary of headers to be sent with the response when receiving data from the stream.
    /// These headers can be used to handle specific conditions for the response.
    /// </summary>
    [JsonPropertyName("response")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? Response { get; set; }
}