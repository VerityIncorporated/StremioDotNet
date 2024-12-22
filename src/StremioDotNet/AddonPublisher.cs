using System.Text;
using System.Text.Json;

namespace StremioDotNet;

/// <summary>
/// Provides functionality to publish addons to the Stremio Central repository.
/// </summary>
public class AddonPublisher
{
    private const string DefaultApiUrl = "https://api.strem.io";

    /// <summary>
    /// Publishes the addon to the Stremio Central repository synchronously.
    /// </summary>
    /// <param name="addonUrl">The public URL of the addon manifest.</param>
    /// <param name="client">An instance of <see cref="HttpClient"/> to make the HTTP request.</param>
    /// <param name="apiUrl">The Stremio API URL (optional). Defaults to the Stremio API if not provided.</param>
    /// <returns>The result of the publication if successful.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="addonUrl"/> or <paramref name="client"/> is null.</exception>
    /// <exception cref="HttpRequestException">Thrown if the HTTP request fails.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the API response indicates an error.</exception>
    public static void PublishToCentral(string addonUrl, HttpClient client, string? apiUrl = null)
    {
        if (string.IsNullOrWhiteSpace(addonUrl))
        {
            throw new ArgumentNullException(nameof(addonUrl), "Addon URL cannot be null or empty.");
        }

        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "HttpClient instance cannot be null.");
        }

        apiUrl ??= DefaultApiUrl;
        var requestUrl = $"{apiUrl}/api/addonPublish";

        var payload = new
        {
            transportUrl = addonUrl,
            transportName = "http"
        };

        var requestBody = JsonSerializer.Serialize(payload);
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = client.PostAsync(requestUrl, content).GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to publish addon: {response.StatusCode} - {response.ReasonPhrase}");
        }

        var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var jsonResponse = JsonSerializer.Deserialize<PublishResponse>(responseBody);

        if (jsonResponse?.Error != null)
        {
            throw new InvalidOperationException($"Error from API: {jsonResponse.Error}");
        }

        if (string.IsNullOrEmpty(jsonResponse?.Result))
            throw new InvalidOperationException("Unexpected response format.");
    }

    /// <summary>
    /// Represents the structure of the API response for addon publication.
    /// </summary>
    private class PublishResponse
    {
        /// <summary>
        /// Gets or sets the result of the publication if successful.
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// Gets or sets the error message if the publication failed.
        /// </summary>
        public string? Error { get; set; }
    }
}