using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Stream;

[StructLayout(LayoutKind.Auto)]
public struct BehaviorHints
{
    [JsonPropertyName("countryWhitelist")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? CountryWhitelist { get; set; }

    [JsonPropertyName("notWebReady")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NotWebReady { get; set; }

    [JsonPropertyName("bingeGroup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BingeGroup { get; set; }

    [JsonPropertyName("proxyHeaders")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ProxyHeaders? ProxyHeaders { get; set; }

    [JsonPropertyName("videoHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VideoHash { get; set; }

    [JsonPropertyName("videoSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? VideoSize { get; set; }

    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Filename { get; set; }
}