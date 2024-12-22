using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// Represents the manifest of a Stremio addon, containing metadata that describes the addon, its resources, content types, catalogs, and other related configurations.
/// The manifest is a required part of the addon to provide Stremio with necessary information about the addon’s functionality and structure.
/// </summary>
public struct Manifest
{
    /// <summary>
    /// A unique, dot-separated identifier for the addon, used to distinguish it within the Stremio ecosystem.
    /// Example: "com.stremio.filmon".
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// A human-readable name of the addon, such as "FilmOn.TV".
    /// This is used to display the addon in the Stremio app interface.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// A human-readable description of the addon, explaining its purpose and functionality.
    /// This text is typically displayed in the addon’s details page in Stremio.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The semantic version of the addon in "major.minor.patch" format.
    /// Example: "1.0.0". This helps Stremio and users track the release and update status of the addon.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// An array of strings representing the resources supported by the addon.
    /// Common examples include "catalog", "meta", "stream", "subtitles", and "addon_catalog". These resources specify what the addon provides to the Stremio platform.
    /// </summary>
    [JsonPropertyName("resources")]
    public string[] Resources { get; set; }

    /// <summary>
    /// An array of strings representing the types of content the addon supports.
    /// These types correspond to Stremio’s content types, such as "movie", "series", "tv", etc.
    /// An addon may support multiple content types.
    /// </summary>
    [JsonPropertyName("types")]
    public string[] Types { get; set; }

    /// <summary>
    /// An optional array of strings representing content ID prefixes that the addon will handle.
    /// This allows filtering which IDs the addon should process. For example, if set to ["yt_id:", "tt"], the addon will only respond to IDs starting with "yt_id:" or "tt".
    /// If not provided, the addon will respond to all content IDs.
    /// </summary>
    [JsonPropertyName("idPrefixes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? IdPrefixes { get; set; }

    /// <summary>
    /// An array of Catalog objects representing the content catalogs provided by the addon.
    /// Each catalog defines a collection of content and its metadata.
    /// </summary>
    [JsonPropertyName("catalogs")]
    public Catalog[] Catalogs { get; set; }

    /// <summary>
    /// An optional array of Catalog objects representing other addon manifests. This can be used when the addon acts as a catalog of other addons, providing access to additional resources.
    /// </summary>
    [JsonPropertyName("addonCatalogs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Catalog[]? AddonCatalogs { get; set; }

    /// <summary>
    /// An optional array of Config objects defining the configuration options for the addon.
    /// These settings can be customized by users to adjust the addon's behavior or appearance.
    /// If omitted, the addon will not have configurable settings.
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Config[]? Config { get; set; }

    /// <summary>
    /// An optional URL pointing to a PNG or JPG image that will be used as the addon's background. The image must be at least 1024x786 pixels.
    /// This background image will be displayed in the Stremio app alongside the addon.
    /// </summary>
    [JsonPropertyName("background")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Background { get; set; }

    /// <summary>
    /// An optional URL pointing to a PNG image that will be used as the addon's logo. The image must be 256x256 pixels.
    /// This logo will be displayed in the Stremio interface for the addon.
    /// </summary>
    [JsonPropertyName("logo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logo { get; set; }

    /// <summary>
    /// An optional contact email address for the addon’s support. This email is used for receiving bug reports or user inquiries.
    /// The Stremio team may also use this email for communication related to the addon.
    /// </summary>
    [JsonPropertyName("contactEmail")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ContactEmail { get; set; }

    /// <summary>
    /// An optional object containing hints about the behavior of the addon. These hints provide additional metadata, such as whether the addon includes adult content or supports peer-to-peer (P2P) streaming.
    /// </summary>
    [JsonPropertyName("behaviorHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BehaviorHints? BehaviorHints { get; set; }
}