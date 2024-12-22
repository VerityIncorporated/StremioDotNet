using StremioDotNet.Structs;
using Stream = StremioDotNet.Structs.Stream;
using Structs_Stream = StremioDotNet.Structs.Stream;

namespace StremioDotNet.Builders;

public class StreamBuilder
{
    private string? url;
    private string? ytId;
    private string? infoHash;
    private int? fileIdx;
    private string? externalUrl;
    private string? name;
    private string? description;
    private List<Subtitle>? subtitles = null;
    private List<string>? sources = null;
    private StreamBehaviorHints? behaviorHints;
    private long? videoSize;
    private string? filename;
    
    public StreamBuilder SetUrl(string? url)
    {
        this.url = url;
        return this;
    }

    public StreamBuilder SetYtId(string? ytId)
    {
        this.ytId = ytId;
        return this;
    }

    public StreamBuilder SetInfoHash(string? infoHash)
    {
        this.infoHash = infoHash;
        return this;
    }

    public StreamBuilder SetFileIdx(int? fileIdx)
    {
        this.fileIdx = fileIdx;
        return this;
    }

    public StreamBuilder SetExternalUrl(string? externalUrl)
    {
        this.externalUrl = externalUrl;
        return this;
    }

    public StreamBuilder SetName(string? name)
    {
        this.name = name;
        return this;
    }

    public StreamBuilder SetDescription(string? description)
    {
        this.description = description;
        return this;
    }

    public StreamBuilder AddSubtitle(string id, string language, string url)
    {
        subtitles ??= [];
        subtitles.Add(new Subtitle { Id = id, Lang = language, Url = url });
        return this;
    }

    public StreamBuilder AddSource(string source)
    {
        sources ??= [];
        sources.Add(source);
        return this;
    }

    public StreamBuilder SetBehaviorHints(bool? notWebReady = null, string? bingeGroup = null, Dictionary<string, string>? requestHeaders = null, Dictionary<string, string>? responseHeaders = null)
    {
        behaviorHints = new StreamBehaviorHints
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

    public StreamBuilder SetVideoSize(long? videoSize)
    {
        this.videoSize = videoSize;
        return this;
    }

    public StreamBuilder SetFilename(string? filename)
    {
        this.filename = filename;
        return this;
    }
    
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

    public Structs_Stream Build()
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
        
        return new Structs_Stream
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