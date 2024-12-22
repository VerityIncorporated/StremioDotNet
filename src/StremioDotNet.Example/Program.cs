using StremioDotNet.Builders;
using StremioDotNet.Extensions;
using StremioDotNet.Structs;

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

app.UseStremioAddon(() => new AddonBuilder(
    "com.example",
    "1.0.0",
    "Example Addon",
    "Example Description",
    [AddonBuilder.Resources.Stream, AddonBuilder.Resources.Meta, AddonBuilder.Resources.Catalog],
    [AddonBuilder.Types.Movie, AddonBuilder.Types.Series],
    ["tt", "ee"]
).SetCatalogs([new Catalog
    {
        Type = "movie",
        Id = "verityMovies",
        Name = "Verity Movies"
    }
]));

app.MapControllers();

app.Run();