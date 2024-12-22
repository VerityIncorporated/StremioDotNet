using StremioDotNet.Structs.Meta;

namespace StremioDotNet.Builders;

/// <summary>
/// The MetaBuilder class provides an easy way to construct a Meta object for Stremio Addons.
/// This builder pattern allows for setting various attributes related to the metadata of 
/// a video, movie, or TV show, without manually interacting with the raw Meta struct.
/// </summary>
public class MetaBuilder
{
    // Unique identifier for the Meta object (e.g., a movie or TV show).
    private readonly string id;
        
    // The type of the media (e.g., Movie, TV Series).
    private readonly string type;
        
    // The name of the media.
    private readonly string name;
        
    // List of genres associated with the media.
    private List<string>? genres;
        
    // URL of the media's poster image.
    private string? poster;
        
    // Shape of the poster (e.g., landscape, portrait).
    private string? posterShape;
        
    // URL of the background image.
    private string? background;
        
    // URL of the logo image.
    private string? logo;
        
    // A description of the media.
    private string? description;
        
    // Release information for the media.
    private string? releaseInfo;
        
    // List of directors associated with the media.
    private List<string>? director;
        
    // List of cast members for the media.
    private List<string>? cast;
        
    // IMDb rating of the media.
    private string? imdbRating;
        
    // Release date of the media.
    private DateTime? released;
        
    // List of trailers related to the media.
    private List<Trailer>? trailers;
        
    // List of external links associated with the media.
    private List<MetaLink>? links;
        
    // List of videos related to the media.
    private List<Video>? videos;
        
    // The runtime of the media.
    private string? runtime;
        
    // The language of the media.
    private string? language;
        
    // The country of origin for the media.
    private string? country;
        
    // Awards received by the media.
    private string? awards;
        
    // Official website of the media.
    private string? website;
        
    // Behavior hints related to the media (e.g., adult content).
    private BehaviorHints? behaviorHints;

    /// <summary>
    /// Initializes a new instance of the <see cref="MetaBuilder"/> class with required parameters.
    /// </summary>
    /// <param name="id">The unique identifier of the media (e.g., movie or TV show).</param>
    /// <param name="type">The type of the media (e.g., Movie, TV Series).</param>
    /// <param name="name">The name of the media.</param>
    public MetaBuilder(string id, string type, string name)
    {
        this.id = id;
        this.type = type;
        this.name = name;
    }

    /// <summary>
    /// Sets the genres for the media.
    /// </summary>
    /// <param name="genres">A list of genres associated with the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetGenres(List<string>? genres)
    {
        this.genres = genres;
        return this;
    }

    /// <summary>
    /// Sets the poster image URL for the media.
    /// </summary>
    /// <param name="poster">The URL of the poster image.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetPoster(string? poster)
    {
        this.poster = poster;
        return this;
    }

    /// <summary>
    /// Sets the poster shape for the media (e.g., landscape, portrait).
    /// </summary>
    /// <param name="posterShape">The shape of the poster image.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetPosterShape(string? posterShape)
    {
        this.posterShape = posterShape;
        return this;
    }

    /// <summary>
    /// Sets the background image URL for the media.
    /// </summary>
    /// <param name="background">The URL of the background image.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetBackground(string? background)
    {
        this.background = background;
        return this;
    }

    /// <summary>
    /// Sets the logo image URL for the media.
    /// </summary>
    /// <param name="logo">The URL of the logo image.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetLogo(string? logo)
    {
        this.logo = logo;
        return this;
    }

    /// <summary>
    /// Sets the description of the media.
    /// </summary>
    /// <param name="description">A short description of the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetDescription(string? description)
    {
        this.description = description;
        return this;
    }

    /// <summary>
    /// Sets the release information for the media.
    /// </summary>
    /// <param name="releaseInfo">Release information for the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetReleaseInfo(string? releaseInfo)
    {
        this.releaseInfo = releaseInfo;
        return this;
    }

    /// <summary>
    /// Sets the director(s) of the media.
    /// </summary>
    /// <param name="director">A list of directors associated with the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetDirector(List<string>? director)
    {
        this.director = director;
        return this;
    }

    /// <summary>
    /// Sets the cast of the media.
    /// </summary>
    /// <param name="cast">A list of cast members for the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetCast(List<string>? cast)
    {
        this.cast = cast;
        return this;
    }

    /// <summary>
    /// Sets the IMDb rating for the media.
    /// </summary>
    /// <param name="imdbRating">The IMDb rating of the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetImdbRating(string? imdbRating)
    {
        this.imdbRating = imdbRating;
        return this;
    }

    /// <summary>
    /// Sets the release date for the media.
    /// </summary>
    /// <param name="released">The release date of the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetReleased(DateTime? released)
    {
        this.released = released;
        return this;
    }

    /// <summary>
    /// Sets the trailers related to the media.
    /// </summary>
    /// <param name="trailers">A list of trailers for the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetTrailers(List<Trailer>? trailers)
    {
        this.trailers = trailers;
        return this;
    }

    /// <summary>
    /// Sets the external links related to the media.
    /// </summary>
    /// <param name="links">A list of external links associated with the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetLinks(List<MetaLink>? links)
    {
        this.links = links;
        return this;
    }

    /// <summary>
    /// Sets the videos related to the media.
    /// </summary>
    /// <param name="videos">A list of videos related to the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetVideos(List<Video>? videos)
    {
        this.videos = videos;
        return this;
    }

    /// <summary>
    /// Sets the runtime of the media.
    /// </summary>
    /// <param name="runtime">The runtime duration of the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetRuntime(string? runtime)
    {
        this.runtime = runtime;
        return this;
    }

    /// <summary>
    /// Sets the language of the media.
    /// </summary>
    /// <param name="language">The language of the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetLanguage(string? language)
    {
        this.language = language;
        return this;
    }

    /// <summary>
    /// Sets the country of origin for the media.
    /// </summary>
    /// <param name="country">The country of origin for the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetCountry(string? country)
    {
        this.country = country;
        return this;
    }

    /// <summary>
    /// Sets the awards received by the media.
    /// </summary>
    /// <param name="awards">The awards won by the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetAwards(string? awards)
    {
        this.awards = awards;
        return this;
    }

    /// <summary>
    /// Sets the official website for the media.
    /// </summary>
    /// <param name="website">The official website URL for the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetWebsite(string? website)
    {
        this.website = website;
        return this;
    }

    /// <summary>
    /// Sets the behavior hints for the media, such as adult content or P2P usage.
    /// </summary>
    /// <param name="behaviorHints">Behavior hints for the media.</param>
    /// <returns>The updated <see cref="MetaBuilder"/> instance.</returns>
    public MetaBuilder SetBehaviorHints(BehaviorHints? behaviorHints)
    {
        this.behaviorHints = behaviorHints;
        return this;
    }

    /// <summary>
    /// Builds and returns the final <see cref="Meta"/> object with the configured values.
    /// </summary>
    /// <returns>The constructed <see cref="Meta"/> object.</returns>
    public Meta Build()
    {
        return new Meta
        {
            Id = this.id,
            Type = this.type,
            Name = this.name,
            Genres = this.genres,
            Poster = this.poster,
            PosterShape = this.posterShape,
            Background = this.background,
            Logo = this.logo,
            Description = this.description,
            ReleaseInfo = this.releaseInfo,
            Director = this.director,
            Cast = this.cast,
            ImdbRating = this.imdbRating,
            Released = this.released,
            Trailers = this.trailers,
            Links = this.links,
            Videos = this.videos,
            Runtime = this.runtime,
            Language = this.language,
            Country = this.country,
            Awards = this.awards,
            Website = this.website,
            BehaviorHints = this.behaviorHints
        };
    }
}