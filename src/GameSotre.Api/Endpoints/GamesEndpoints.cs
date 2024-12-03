using GameSotre.Api.Dtos;

namespace GameSotre.Api.Endpoints;

public static class GamesEndpoints
{
	public const string ENDPOINT_GET_GAME = "GetGame";


	private static readonly List<GameDto> games = new List<GameDto>()
	{
		new GameDto(1, "Street Fighter II", "Fighting", 19.99m, new DateOnly(1992, 7, 15)),
		new GameDto(2, "Final Fantasy XIV", "Role playing", 59.99m, new DateOnly(2010, 9, 30)),
		new GameDto(3, "FIFA 23", "Sports", 69.99m, new DateOnly(2022, 9, 27)),
	};


	public static WebApplication MapGamesEndpoints(this WebApplication app)
	{
		var gamesGroup = app.MapGroup("games");


		// GET /games
		gamesGroup.MapGet("/", () => games);


		// GET /games/1
		gamesGroup.MapGet("/{id}", (int id) =>
		{
			var game = games.Find(game => game.Id == id);

			if (null == game)
			{
				return Results.NotFound();
			}

			return Results.Ok(game);

			// .WithName defines a name for the endpoint
		})
		.WithName(ENDPOINT_GET_GAME);


		// POST /games
		gamesGroup.MapPost("/", (CreateGameDto newGame) =>
		{
			var game = new GameDto(
				games.Select(game => game.Id).Max() + 1,
				newGame.Name,
				newGame.Genre,
				newGame.Price,
				newGame.ReleaseDate);

			games.Add(game);

			return Results.CreatedAtRoute(ENDPOINT_GET_GAME, new { id = game.Id }, game);
		});


		// PUT /games/1
		gamesGroup.MapPut("/{id}", (int id, UpdateGameDto gameData) =>
		{
			var game = games.Find(game => game.Id == id);

			if (null == game)
			{
				// tutor prefers to not do and "upsert" but rather return notFound
				// becuase dB with autoIncrementing ids create confusion when adding a new object
				// with a different Id when an upsert call is executed with a specific Id.
				return Results.NotFound();
			}

			var index = games.IndexOf(game);
			games[index] = game with
			{
				Name = gameData.Name,
				Genre = gameData.Genre,
				Price = gameData.Price,
				ReleaseDate = gameData.ReleaseDate,
			};

			return Results.NoContent();
		});


		// DELETE /games/1
		gamesGroup.MapDelete("/{id}", (int id) =>
		{
			games.RemoveAll(game => game.Id == id);
			return Results.NoContent();
		});


		return app;
	}
}
