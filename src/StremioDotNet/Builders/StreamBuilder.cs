using StremioDotNet.Structs.Stream;
using Stream = StremioDotNet.Structs.Stream.Stream;

namespace StremioDotNet.Builders;

/// <summary>
/// Builder class for constructing a <see cref="StremioDotNet.Structs.Stream.Stream"/> object.
/// Allows for the configuration of various stream properties like URL, subtitles, and behavior hints.
/// </summary>
public class StreamBuilder
{
    private string? url;
    private string? ytId;
    private string? infoHash;
    private int? fileIdx;
    private string? externalUrl;
    private string? name;
    private string? description;
    private List<Subtitle>? subtitles;
    private List<string>? sources;
    private BehaviorHints? behaviorHints;
    private long? videoSize;
    private string? filename;

    /// <summary>
    /// Sets the URL of the stream.
    /// </summary>
    /// <param name="url">The URL of the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetUrl(string? url)
    {
        this.url = url;
        return this;
    }

    /// <summary>
    /// Sets the YouTube ID of the stream.
    /// </summary>
    /// <param name="ytId">The YouTube ID for the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetYtId(string? ytId)
    {
        this.ytId = ytId;
        return this;
    }

    /// <summary>
    /// Sets the info hash for torrent-based streams.
    /// </summary>
    /// <param name="infoHash">The info hash for the torrent.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetInfoHash(string? infoHash)
    {
        this.infoHash = infoHash;
        return this;
    }

    /// <summary>
    /// Sets the file index for torrent-based streams.
    /// </summary>
    /// <param name="fileIdx">The file index within the torrent.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetFileIdx(int? fileIdx)
    {
        this.fileIdx = fileIdx;
        return this;
    }

    /// <summary>
    /// Sets the external URL of the stream (if applicable).
    /// </summary>
    /// <param name="externalUrl">The external URL for the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetExternalUrl(string? externalUrl)
    {
        this.externalUrl = externalUrl;
        return this;
    }

    /// <summary>
    /// Sets the name of the stream.
    /// </summary>
    /// <param name="name">The name of the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetName(string? name)
    {
        this.name = name;
        return this;
    }

    /// <summary>
    /// Sets the description of the stream.
    /// </summary>
    /// <param name="description">A description of the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetDescription(string? description)
    {
        this.description = description;
        return this;
    }

    /// <summary>
    /// Adds a subtitle to the stream.
    /// </summary>
    /// <param name="id">The ID of the subtitle.</param>
    /// <param name="language">The language of the subtitle.</param>
    /// <param name="url">The URL for downloading the subtitle.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder AddSubtitle(string id, string language, string url)
    {
        subtitles ??= [];
        subtitles.Add(new Subtitle { Id = id, Lang = language, Url = url });
        return this;
    }

    /// <summary>
    /// Adds a source URL to the stream.
    /// </summary>
    /// <param name="source">A source URL for the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder AddSource(string source)
    {
        sources ??= new List<string>();
        sources.Add(source);
        return this;
    }

    /// <summary>
    /// Sets the behavior hints for the stream, such as readiness for web use, binge group, and proxy headers.
    /// </summary>
    /// <param name="notWebReady">Indicates if the stream is not ready for web use.</param>
    /// <param name="bingeGroup">The binge group associated with the stream.</param>
    /// <param name="requestHeaders">Custom headers for the request proxy.</param>
    /// <param name="responseHeaders">Custom headers for the response proxy.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetBehaviorHints(bool? notWebReady = null, string? bingeGroup = null, Dictionary<string, string>? requestHeaders = null, Dictionary<string, string>? responseHeaders = null)
    {
        behaviorHints = new BehaviorHints
        {
            NotWebReady = notWebReady ?? behaviorHints?.NotWebReady,
            BingeGroup = bingeGroup ?? behaviorHints?.BingeGroup,
            ProxyHeaders = new ProxyHeaders
            {
                Request = requestHeaders ?? behaviorHints?.ProxyHeaders?.Request,
                Response = responseHeaders ?? behaviorHints?.ProxyHeaders?.Response
            }
        };
        return this;
    }

    /// <summary>
    /// Sets the video size for the stream in bytes.
    /// </summary>
    /// <param name="videoSize">The size of the video in bytes.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetVideoSize(long? videoSize)
    {
        this.videoSize = videoSize;
        return this;
    }

    /// <summary>
    /// Sets the filename associated with the stream.
    /// </summary>
    /// <param name="filename">The filename for the stream.</param>
    /// <returns>The current instance of <see cref="StreamBuilder"/> for method chaining.</returns>
    public StreamBuilder SetFilename(string? filename)
    {
        this.filename = filename;
        return this;
    }

    /// <summary>
    /// Creates a pre-configured <see cref="StreamBuilder"/> for a torrent stream.
    /// </summary>
    /// <param name="infoHash">The info hash of the torrent.</param>
    /// <param name="fileIdx">The file index within the torrent (optional).</param>
    /// <returns>A <see cref="StreamBuilder"/> instance configured for a torrent stream.</returns>
    public static StreamBuilder TorrentStream(string infoHash, int? fileIdx)
    {
        var builder = new StreamBuilder()
            .SetInfoHash(infoHash);

        if (fileIdx.HasValue)
        {
            builder.SetFileIdx(fileIdx.Value);
        }

        return builder;
    }

    /// <summary>
    /// Builds the final <see cref="StremioDotNet.Structs.Stream.Stream"/> object.
    /// Ensures exactly one of 'url', 'ytId', 'infoHash', or 'externalUrl' is provided.
    /// </summary>
    /// <returns>A fully constructed <see cref="StremioDotNet.Structs.Stream.Stream"/> object with the configured properties.</returns>
    /// <exception cref="InvalidOperationException">Thrown when none or more than one of the required fields ('url', 'ytId', 'infoHash', 'externalUrl') are provided.</exception>
    public Stream Build()
    {
        var definedFields = 0;
        if (!string.IsNullOrEmpty(url)) definedFields++;
        if (!string.IsNullOrEmpty(ytId)) definedFields++;
        if (!string.IsNullOrEmpty(infoHash)) definedFields++;
        if (!string.IsNullOrEmpty(externalUrl)) definedFields++;

        if (definedFields != 1)
        {
            throw new InvalidOperationException("Exactly one of 'url', 'ytId', 'infoHash', or 'externalUrl' must be provided.");
        }
            
        return new Stream
        {
            Url = url,
            YtId = ytId,
            InfoHash = infoHash,
            FileIdx = fileIdx,
            ExternalUrl = externalUrl ?? null,
            Name = name ?? string.Empty,
            Description = description ?? string.Empty,
            Subtitles = subtitles,
            Sources = sources,
            BehaviorHints = behaviorHints,
        };
    }
}