using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// Contains information about the qualities of the addon
/// </summary>
public struct BehaviorHints
{
    /// <summary>
    /// Whether the addon is related to adult content. Used to provide an adequate warning to the user.
    /// </summary>
    [JsonPropertyName("adult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Adult { get; set; }
    
    /// <summary>
    /// Whether the addon includes peer-to-peer content such as BitTorrent, which mmay reveal the user's IP address to other streaming parties. Used to provide an adequate warning to the user.
    /// </summary>
    [JsonPropertyName("p2p")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? P2P { get; set; }

    /// <summary>
    /// Whether the addon supports settings. Adds a button next to "Install" in Stremio that will point to the /configure path on the addon's domain.
    /// </summary>
    [JsonPropertyName("configurable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Configurable { get; set; }

    /// <summary>
    /// Whether the addon must be configured. If true, the "Install" button will not show for your addon in Stremio. Instead, a "Configure" button will be shown, pointing to the /configure path on the addon's domain.
    /// </summary>
    [JsonPropertyName("configurationRequired")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ConfigurationRequired { get; set; }
}