using StremioDotNet.Builders;
using StremioDotNet.Extensions;
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
        Name = "StremioDotNet Movies"
    }
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
