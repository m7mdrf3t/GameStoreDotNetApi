using GameStore.Data;
using Microsoft.EntityFrameworkCore;
using GameStore.EndPoints;
using GameStore.DataMigration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsql<GameStoreContext>(builder.Configuration.GetConnectionString("GameStore"));
builder.Services.AddScoped<GameStoreContext>();

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenreEndpoint();

await app.MigrateDbAsync();

app.Run();

