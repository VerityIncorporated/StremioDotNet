using StremioDotNet.Builders;
using StremioDotNet.Extensions;
using StremioDotNet.ModelBinders;
using StremioDotNet.Structs.Manifest;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddStremio();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

AddonBuilder ConfigureAddon() => new AddonBuilder(
    "com.example",
    "1.0.0",
    "Example Addon",
    "Example Description",
    [AddonBuilder.Resources.Stream, AddonBuilder.Resources.Meta, AddonBuilder.Resources.Catalog],
    ["movie", "series"],
    ["tt", "ee"]
).SetCatalogs([
    new Catalog
    {
        Type = "movie",
        Id = "stremioDotNet",
        Name = "StremioDotNet Movies",
        Extra = [new Extra
            {
                Name = "search",
                IsRequired = false,
            }
        ]
    }
]).SetBehaviorHints(configurable: true).SetConfig([new Config
    {
        Key = "testText",
        Type = Config.ConfigType.Text,
        Title = "Test Text",
    },
    new Config
    {
        Key = "testPassword",
        Type = Config.ConfigType.Password,
        Title = "Test Password"
    },
    new Config
    {
        Key = "testCheckBoxSingle",
        Type = Config.ConfigType.Checkbox,
        Title = "Test Checkbox (Single)",
        Options = ["Enabled Something"]
    },
    new Config
    {
        Key = "testCheckBoxMulti",
        Type = Config.ConfigType.Checkbox,
        Title = "Test Checkbox (Multi)",
        Options = ["Enabled Something", "Enabled Something Else"]
    },
    new Config
    {
        Key = "testSelect",
        Type = Config.ConfigType.Select,
        Title = "Test Select",
        Options = ["Select This", "Select That"]
    },
]);

if (app.Environment.IsProduction())
{
    app.UseStremioAddon(() => ConfigureAddon().PublishToCentral("https://stremio.nathan.rip")); // if its production we want to publish it.
}
else
{
    app.UseStremioAddon(ConfigureAddon);
}

app.MapControllers();

app.Run();
