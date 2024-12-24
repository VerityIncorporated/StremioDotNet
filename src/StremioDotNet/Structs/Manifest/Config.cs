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
        /// <summary>
        /// Represents a text-based configuration setting, typically for freeform text input.
        /// </summary>
        Text,

        /// <summary>
        /// Represents a numeric configuration setting, used for integers or decimals.
        /// </summary>
        Number,

        /// <summary>
        /// Represents a password configuration setting, typically for secure or masked input.
        /// </summary>
        Password,

        /// <summary>
        /// Represents a boolean configuration setting, displayed as a checkbox.
        /// </summary>
        Checkbox,

        /// <summary>
        /// Represents a configuration setting with predefined options, typically displayed as a dropdown or select menu.
        /// </summary>
        Select
    }

    /// <summary>
    /// Custom JSON converter to serialize and deserialize enums as lowercase strings.
    /// </summary>
    /// <typeparam name="T">The enum type to be converted.</typeparam>
    public class LowercaseEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        /// <summary>
        /// Reads and converts the JSON representation of the enum to the appropriate enum value.
        /// </summary>
        /// <param name="reader">The UTF-8 JSON reader.</param>
        /// <param name="typeToConvert">The type of object to convert.</param>
        /// <param name="options">The serializer options to use.</param>
        /// <returns>The enum value that corresponds to the JSON string.</returns>
        /// <exception cref="JsonException">
        /// Thrown when the JSON string does not match any valid value of the enum.
        /// </exception>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Read the string from the JSON input and convert it to lowercase
            var value = reader.GetString()?.ToLowerInvariant();

            // Attempt to parse the string into the enum type
            if (Enum.TryParse(value, true, out T result))
            {
                return result;
            }

            // Throw an exception if the value is invalid
            throw new JsonException($"Invalid value '{value}' for enum type '{typeof(T).Name}'.");
        }

        /// <summary>
        /// Writes the enum value as a lowercase string to the JSON output.
        /// </summary>
        /// <param name="writer">The UTF-8 JSON writer.</param>
        /// <param name="value">The enum value to write.</param>
        /// <param name="options">The serializer options to use.</param>
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            // Convert the enum value to its string representation and write it in lowercase
            writer.WriteStringValue(value.ToString().ToLowerInvariant());
        }
    }
}