using System.Text.Json;
using System.Text.Json.Serialization;

namespace StremioDotNet.Structs.Manifest;

/// <summary>
/// Represents the configuration format for a setting in the manifest.
/// </summary>
public struct Config
{
    /// <summary>
    /// Gets or sets the key that identifies the user-chosen value.
    /// </summary>
    /// <remarks>
    /// This field is required.
    /// </remarks>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the type of the configuration setting.
    /// </summary>
    /// <remarks>
    /// This field is required and can be one of the following values:
    /// "text", "number", "password", "checkbox", or "select".
    /// </remarks>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(LowercaseEnumConverter<ConfigType>))]
    public ConfigType Type { get; set; }

    /// <summary>
    /// Gets or sets the default value for the configuration setting.
    /// </summary>
    /// <remarks>
    /// This field is optional. For <c>type</c> "boolean", this can be set to "checked" to default to enabled.
    /// </remarks>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Default { get; set; }

    /// <summary>
    /// Gets or sets the title of the setting.
    /// </summary>
    /// <remarks>
    /// This field is optional.
    /// </remarks>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the list of choices for <c>type</c>: "select".
    /// </summary>
    /// <remarks>
    /// This field is optional and applies only to <c>type</c>: "select".
    /// Each choice is represented as a string.
    /// </remarks>
    [JsonPropertyName("options")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? Options { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the setting is required.
    /// </summary>
    /// <remarks>
    /// This field is optional and applies only to <c>type</c>: "string" and "number".
    /// The default value is <c>false</c>.
    /// </remarks>
    [JsonPropertyName("required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Required { get; set; }
    
    /// <summary>
    /// Enum representing the valid types for a configuration setting.
    /// </summary>
    public enum ConfigType
    {
        Text,
        Number,
        Password,
        Checkbox,
        Select
    }
    
    /// <summary>
    /// Custom JSON converter to serialize and deserialize enums as lowercase strings.
    /// </summary>
    /// <typeparam name="T">The enum type to be converted.</typeparam>
    public class LowercaseEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString()?.ToLowerInvariant();
            if (Enum.TryParse(value, true, out T result))
            {
                return result;
            }

            throw new JsonException($"Invalid value '{value}' for enum type '{typeof(T).Name}'.");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToLowerInvariant());
        }
    }
}