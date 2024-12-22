using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// Extra parameters for a catalog
/// </summary>
public struct Extra
{
    /// <summary>
    /// The name of the property
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Whether this property must always be passed
    /// </summary>
    [JsonPropertyName("isRequired")]
    public bool IsRequired { get; set; }

    /// <summary>
    /// Possible values for this property. Useful for things like genres, where you need the user to select from a pre-set list of options.
    /// </summary>
    [JsonPropertyName("options")]
    public string[] Options { get; set; }

    /// <summary>
    /// The limit of values a user may select from the pre-set <see cref="Options"/> list.
    /// </summary>
    [JsonPropertyName("optionsLimit")]
    public int OptionsLimit { get; set; }
}