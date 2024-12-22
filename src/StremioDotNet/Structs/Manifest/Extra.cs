using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// Extra parameters for a catalog.
/// These parameters define additional query options that can be passed when requesting catalog data from the addon.
/// They enable features such as search functionality, filtering by genre, or pagination of results.
/// </summary>
public struct Extra
{
    /// <summary>
    /// The name of the property.
    /// This represents the key for the additional parameter and will appear in the query string as part of the `extraProps` object in catalog requests.
    /// For example, it could be "search" for full-text search or "genre" for filtering by genres.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Whether this property must always be passed.
    /// If set to `true`, Stremio will only make catalog requests that include this parameter.
    /// This is particularly useful for catalogs that require a search query or other mandatory filters to function properly.
    /// </summary>
    [JsonPropertyName("isRequired")]
    public bool IsRequired { get; set; }

    /// <summary>
    /// Possible values for this property.
    /// If provided, this array specifies the predefined values that the user or the system can select for this parameter.
    /// For instance, when using the "genre" property, the options might include "Action," "Comedy," and "Drama."
    /// </summary>
    [JsonPropertyName("options")]
    public string[] Options { get; set; }

    /// <summary>
    /// The limit of values a user may select from the pre-set <see cref="Options"/> list.
    /// By default, this is set to 1, meaning only a single value can be selected.
    /// This can be increased to allow multiple selections, such as choosing multiple genres for filtering.
    /// </summary>
    [JsonPropertyName("optionsLimit")]
    public int OptionsLimit { get; set; }
}