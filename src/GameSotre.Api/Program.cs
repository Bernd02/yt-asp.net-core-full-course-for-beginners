using GameSotre.Api.Endpoints;
using GameStore.Data;


var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreDbContext>(connectionString);


// --------------------------------------------------
var app = builder.Build();

app.MapGamesEndpoints();

app.Run();

