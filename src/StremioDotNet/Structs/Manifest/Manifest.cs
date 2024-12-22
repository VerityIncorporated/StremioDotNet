using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// 
/// </summary>
public struct Manifest
{
    /// <summary>
    /// Dot-separated identifier, e.g. "com.stremio.filmon"
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Human-readable name, e.g. "FilmOn.TV"
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Human-readable description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// Semantic version of the addon
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// Supported resources - for example, ["catalog", "meta", "stream", "subtitles", "addon_catalog"]
    /// </summary>
    [JsonPropertyName("resources")]
    public string[] Resources { get; set; }

    /// <summary>
    /// Supported content types
    /// </summary>
    [JsonPropertyName("types")]
    public string[] Types { get; set; }

    /// <summary>
    /// Content ID prefixes that this addon will be called for
    /// </summary>
    [JsonPropertyName("idPrefixes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? IdPrefixes { get; set; }

    /// <summary>
    /// A list of the content catalogs that the addon provides
    /// </summary>
    [JsonPropertyName("catalogs")]
    public Catalog[] Catalogs { get; set; }

    /// <summary>
    /// A list of other addon manifests, this can be used for an addon to act just as a catalog of other addons
    /// </summary>
    [JsonPropertyName("addonCatalogs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Catalog[]? AddonCatalogs { get; set; }

    /// <summary>
    /// A list of settings that users can set for your addon
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Config[]? Config { get; set; }

    /// <summary>
    /// A URL to a PNG or JPG image that will be used as the addon's background. Minimum size is 1024x786.
    /// </summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>
    /// A URL to a PNG that will be used as the addon's logo. Must be 256x256.
    /// </summary>
    [JsonPropertyName("logo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logo { get; set; }

    /// <summary>
    /// Contact e-mail address for addon issues. Used for the in-app Report button. Also, the Stremio team may reach you via this address for anything related to your addon.
    /// </summary>
    [JsonPropertyName("contactEmail")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Information about qualities of the addon
    /// </summary>
    [JsonPropertyName("behaviorHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BehaviorHints? BehaviorHints { get; set; }
}