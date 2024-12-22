﻿using StremioDotNet.Structs.Manifest;

namespace StremioDotNet.Builders;

/// <summary>
/// The AddonBuilder class helps to easily build and configure an Addon Manifest for Stremio Addons,
/// without directly interacting with the raw structs. It allows setting behavior hints, catalogs, 
/// and other configurations necessary for creating a Stremio Addon Manifest.
/// </summary>
public class AddonBuilder
{
    // Unique identifier for the Addon.
    private readonly string id;
        
    // Version of the Addon.
    private readonly string version;
        
    // Name of the Addon.
    private readonly string name;
        
    // Description of the Addon.
    private readonly string description;
        
    // The resources that the Addon supports (e.g. Stream, Catalog, Meta, Subtitles).
    private readonly Resources[] resources;
        
    // Types that the Addon supports (e.g. Movie, TV Series, etc.).
    private readonly string[] types;
        
    // ID prefixes used for the Addon.
    private readonly string[] idPrefixes;
        
    // Optional behavior hints for the Addon (e.g. whether it contains adult content).
    private BehaviorHints? behaviorHints;
        
    // The catalogs that the Addon exposes.
    private Catalog[] catalogs = [];
        
    // Configuration settings for the Addon.
    private Config[]? config;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonBuilder"/> class with required parameters.
    /// </summary>
    /// <param name="id">The unique identifier of the Addon.</param>
    /// <param name="version">The version of the Addon.</param>
    /// <param name="name">The name of the Addon.</param>
    /// <param name="description">A short description of the Addon.</param>
    /// <param name="resources">An array of resources the Addon supports (e.g. Stream, Catalog, Meta, Subtitles).</param>
    /// <param name="types">An array of types that the Addon supports (e.g. movie, series, etc.).</param>
    /// <param name="idPrefixes">An array of ID prefixes used for the Addon.</param>
    public AddonBuilder(
        string id,
        string version,
        string name,
        string description,
        Resources[] resources,
        string[] types,
        string[] idPrefixes)
    {
        this.id = id;
        this.version = version;
        this.name = name;
        this.description = description;
        this.resources = resources;
        this.types = types;
        this.idPrefixes = idPrefixes;
    }

    /// <summary>
    /// Sets the behavior hints for the Addon, such as whether it contains adult content or requires configuration.
    /// </summary>
    /// <param name="adult">Indicates if the Addon contains adult content.</param>
    /// <param name="p2p">Indicates if the Addon uses P2P (peer-to-peer) technology.</param>
    /// <param name="configurable">Indicates if the Addon is configurable.</param>
    /// <param name="configurationRequired">Indicates if configuration is required for the Addon.</param>
    /// <returns>The updated <see cref="AddonBuilder"/> instance.</returns>
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

    /// <summary>
    /// Sets the catalogs for the Addon. Catalogs are used to categorize the Addon's content.
    /// </summary>
    /// <param name="catalogs">An array of catalogs the Addon exposes.</param>
    /// <returns>The updated <see cref="AddonBuilder"/> instance.</returns>
    public AddonBuilder SetCatalogs(Catalog[] catalogs)
    {
        this.catalogs = catalogs;
        return this;
    }

    /// <summary>
    /// Sets the configuration settings for the Addon.
    /// </summary>
    /// <param name="config">An array of configuration settings for the Addon.</param>
    /// <returns>The updated <see cref="AddonBuilder"/> instance.</returns>
    public AddonBuilder SetConfig(Config[] config)
    {
        this.config = config;
        return this;
    }

    /// <summary>
    /// Builds the Addon Manifest using the provided configuration.
    /// </summary>
    /// <returns>A <see cref="Manifest"/> instance representing the Addon configuration.</returns>
    public Manifest BuildManifest()
    {
        return new Manifest
        {
            Id = id,
            Version = version,
            Name = name,
            Description = description,
            Resources = resources.Select(r => r.ToString().ToLower()).ToArray(),
            Types = types,
            IdPrefixes = idPrefixes,
            BehaviorHints = behaviorHints,
            Catalogs = catalogs,
            Config = config
        };
    }

    /// <summary>
    /// Enum representing the different types of resources that an Addon can expose.
    /// </summary>
    public enum Resources
    {
        /// <summary>Represents streaming resources.</summary>
        Stream,

        /// <summary>Represents catalog resources.</summary>
        Catalog,

        /// <summary>Represents metadata resources.</summary>
        Meta,

        /// <summary>Represents subtitle resources.</summary>
        Subtitles
    }
}