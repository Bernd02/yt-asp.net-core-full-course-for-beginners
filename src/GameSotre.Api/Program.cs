using GameSotre.Api.Endpoints;
using GameSotre.Api.Extensions;
using GameStore.Data;
using GameStore.Data.Services.GameService;
using GameStore.Data.Services.GenreService;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreDbContext>(connectionString);

builder.Services.AddScoped<IGameService, EfSqliteGameService>();
builder.Services.AddScoped<IGenreService, EfSqliteGenreService>();


// --------------------------------------------------
var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();

