using StremioDotNet.Structs;
using StremioDotNet.Structs.Meta;

namespace StremioDotNet.Builders;

public class MetaBuilder(string id, string type, string name)
{
    private List<string>? genres;
    private string? poster;
    private string? posterShape;
    private string? background;
    private string? logo;
    private string? description;
    private string? releaseInfo;
    private List<string>? director;
    private List<string>? cast;
    private string? imdbRating;
    private DateTime? released;
    private List<Trailer>? trailers;
    private List<MetaLink>? links;
    private List<Video>? videos;
    private string? runtime;
    private string? language;
    private string? country;
    private string? awards;
    private string? website;
    private MetaBehaviorHints? behaviorHints;

    public MetaBuilder SetGenres(List<string>? genres)
    {
        this.genres = genres;
        return this;
    }

    public MetaBuilder SetPoster(string? poster)
    {
        this.poster = poster;
        return this;
    }

    public MetaBuilder SetPosterShape(string? posterShape)
    {
        this.posterShape = posterShape;
        return this;
    }

    public MetaBuilder SetBackground(string? background)
    {
        this.background = background;
        return this;
    }

    public MetaBuilder SetLogo(string? logo)
    {
        this.logo = logo;
        return this;
    }

    public MetaBuilder SetDescription(string? description)
    {
        this.description = description;
        return this;
    }

    public MetaBuilder SetReleaseInfo(string? releaseInfo)
    {
        this.releaseInfo = releaseInfo;
        return this;
    }

    public MetaBuilder SetDirector(List<string>? director)
    {
        this.director = director;
        return this;
    }

    public MetaBuilder SetCast(List<string>? cast)
    {
        this.cast = cast;
        return this;
    }

    public MetaBuilder SetImdbRating(string? imdbRating)
    {
        this.imdbRating = imdbRating;
        return this;
    }

    public MetaBuilder SetReleased(DateTime? released)
    {
        this.released = released;
        return this;
    }

    public MetaBuilder SetTrailers(List<Trailer>? trailers)
    {
        this.trailers = trailers;
        return this;
    }

    public MetaBuilder SetLinks(List<MetaLink>? links)
    {
        this.links = links;
        return this;
    }

    public MetaBuilder SetVideos(List<Video>? videos)
    {
        this.videos = videos;
        return this;
    }

    public MetaBuilder SetRuntime(string? runtime)
    {
        this.runtime = runtime;
        return this;
    }

    public MetaBuilder SetLanguage(string? language)
    {
        this.language = language;
        return this;
    }

    public MetaBuilder SetCountry(string? country)
    {
        this.country = country;
        return this;
    }

    public MetaBuilder SetAwards(string? awards)
    {
        this.awards = awards;
        return this;
    }

    public MetaBuilder SetWebsite(string? website)
    {
        this.website = website;
        return this;
    }

    public MetaBuilder SetBehaviorHints(MetaBehaviorHints? behaviorHints)
    {
        this.behaviorHints = behaviorHints;
        return this;
    }

    public Meta Build()
    {
        return new Meta
        {
            Id = id,
            Type = type,
            Name = name,
            Genres = genres,
            Poster = poster,
            PosterShape = posterShape,
            Background = background,
            Logo = logo,
            Description = description,
            ReleaseInfo = releaseInfo,
            Director = director,
            Cast = cast,
            ImdbRating = imdbRating,
            Released = released,
            Trailers = trailers,
            Links = links,
            Videos = videos,
            Runtime = runtime,
            Language = language,
            Country = country,
            Awards = awards,
            Website = website,
            BehaviorHints = behaviorHints
        };
    }
}