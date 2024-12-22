using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// Contains information about the qualities of the addon.
/// Provides metadata that influences how the addon is displayed, configured, or interacted with in Stremio.
/// </summary>
public struct BehaviorHints
{
    /// <summary>
    /// Whether the addon is related to adult content.
    /// If set to true, Stremio will display an appropriate warning to the user before they interact with the addon.
    /// This is useful for addons offering content that is restricted by age or considered sensitive in nature.
    /// </summary>
    [JsonPropertyName("adult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Adult { get; set; }
    
    /// <summary>
    /// Whether the addon includes peer-to-peer content such as BitTorrent.
    /// When enabled, it alerts users that their IP address may be exposed to other parties during streaming, ensuring transparency about potential privacy implications.
    /// This is particularly relevant for addons that rely on decentralized technologies for content delivery.
    /// </summary>
    [JsonPropertyName("p2p")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? P2P { get; set; }

    /// <summary>
    /// Whether the addon supports settings.
    /// If true, Stremio will add a button next to "Install" in the user interface, which links to the /configure path on the addon's domain.
    /// This allows users to modify settings or preferences specific to the addon, enabling customization of its behavior or content delivery.
    /// </summary>
    [JsonPropertyName("configurable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Configurable { get; set; }

    /// <summary>
    /// Whether the addon must be configured.
    /// If set to true, the "Install" button will be hidden, and instead, a "Configure" button will appear in Stremio.
    /// This is useful for addons that require mandatory user inputs, such as API keys or specific settings, before they can function properly.
    /// The "Configure" button will redirect users to the /configure path on the addon's domain to complete the required setup.
    /// </summary>
    [JsonPropertyName("configurationRequired")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ConfigurationRequired { get; set; }
}