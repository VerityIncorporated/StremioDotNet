using Microsoft.AspNetCore.Mvc;
using StremioDotNet.Attributes;
using StremioDotNet.Builders;
using StremioDotNet.Structs;
using static StremioDotNet.Results.MetaResult;

namespace StremioDotNet.Example.Controllers;

[ApiController]
public class MetaController : ControllerBase
{
    [MetaHandler]
    public IActionResult MetaHandler(string type, string id)
    {
        var metaBuilder = new MetaBuilder("eeolivertwists", type, "Oliver Twists")
            .SetDescription(
                "Meet Oliver, a once-adorable ferret turned unhinged party animal with a crippling addiction to powdered anise (a.k.a. “The Spice”). In the sleepy town of Dusty Pines, Oliver’s spiral into the shady world of exotic pet narcotics starts innocently enough—a nip here, a snort there—until he becomes the unexpected kingpin of a black market operation run from beneath the snack aisle of the local pet store.\n\nThings get hairy when Oliver’s empire threatens the turf of Squeaky Malone, a power-hungry guinea pig with delusions of grandeur. Forced to fight for his life and his stash, Oliver teams up with Polly, a caffeine-addicted parrot who swears she was once a pirate, and Mr. Whiskers, a washed-up alley cat who “used to be somebody in the cat food commercials.” Together, they must dodge animal control, outwit their rivals, and help Oliver face the hardest challenge of all: kicking his addiction before his entire empire (and his beloved hammock) comes crashing down.\n\nPacked with ferret acrobatics, absurd animal hijinks, and one too many litterbox metaphors, Oliver Twists is a no-holds-barred satire of addiction, ambition, and the surprisingly cutthroat world of pet store politics. Rated PG-13 for mild fur-flying action and excessive use of squeak puns.\n")
            .SetDirector(["Aiden Douglas Smith", "Nathan Roberts"])
            .SetRuntime("12 Days")
            .SetReleased(DateTime.Today - TimeSpan.FromDays(42))
            .SetLogo("https://r2.e-z.host/oliver.png")
            .SetPoster("https://r2.e-z.host/oliver.png")
            .SetBackground("https://r2.e-z.host/oliver.png")
            .SetGenres(["Horror", "Drama"])
            .SetAwards("Best Movie Ever")
            .SetImdbRating("10.0")
            .SetReleaseInfo("2024")
            .SetLinks([
                new MetaLink
                {
                    Name = "10",
                    Category = "imdb",
                    Url = "https://r2.e-z.host/oliver.png"
                }
            ]).Build();

        return Meta(metaBuilder);
    }
}