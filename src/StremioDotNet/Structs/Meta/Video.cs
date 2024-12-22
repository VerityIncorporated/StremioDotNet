using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Meta;

public struct Video
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("released")]
    public DateTime Released { get; set; }

    [JsonPropertyName("thumbnail")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Thumbnail { get; set; }

    [JsonPropertyName("streams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Stream.Stream> Streams { get; set; }

    [JsonPropertyName("available")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Available { get; set; }

    [JsonPropertyName("episode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Episode { get; set; }

    [JsonPropertyName("season")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Season { get; set; }

    [JsonPropertyName("trailers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<System.IO.Stream> Trailers { get; set; }

    [JsonPropertyName("overview")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Overview { get; set; }
}