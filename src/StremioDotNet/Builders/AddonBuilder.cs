using StremioDotNet.Structs;

namespace StremioDotNet.Builders;

public class AddonBuilder(
    string id,
    string version,
    string name,
    string description,
    AddonBuilder.Resources[] resources,
    AddonBuilder.Types[] types,
    string[] idPrefixes)
{
    private BehaviorHints? behaviorHints;
    private Catalog[] catalogs = [];
    private Config[]? config;

    public AddonBuilder SetBehaviorHints(
        bool? adult = null,
        bool? p2p = null,
        bool? configurable = null,
        bool? configurationRequired = null)
    {
        behaviorHints = new BehaviorHints
        {
            Adult = adult ?? behaviorHints?.Adult,
            P2P = p2p ?? behaviorHints?.P2P,
            Configurable = configurable ?? behaviorHints?.Configurable,
            ConfigurationRequired = configurationRequired ?? behaviorHints?.ConfigurationRequired
        };
        return this;
    }

    public AddonBuilder SetCatalogs(Catalog[] catalogs)
    {
        this.catalogs = catalogs;
        return this;
    }

    public AddonBuilder SetConfig(Config[] config)
    {
        this.config = config;
        return this;
    }

    public Manifest BuildManifest()
    {
        return new Manifest
        {
            Id = id,
            Version = version,
            Name = name,
            Description = description,
            Resources = resources.Select(r => r.ToString().ToLower()).ToArray(),
            Types = types.Select(t => t.ToString().ToLower()).ToArray(),
            IdPrefixes = idPrefixes,
            BehaviorHints = behaviorHints,
            Catalogs = catalogs,
            Config = config
        };
    }

    public enum Resources
    {
        Stream,
        Catalog,
        Meta,
        Subtitles
    }

    public enum Types
    {
        Movie,
        Series,
        Channel,
        Tv
    }
}