using GameSotre.Api.Data;
using GameSotre.Api.Endpoints;
using GameStore.Data;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreDbContext>(connectionString);


// --------------------------------------------------
var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();

