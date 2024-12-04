using GameSotre.Api.Dtos;
using GameSotre.Api.Extensions;
using GameStore.Services.GameService;
using Microsoft.AspNetCore.Mvc;

namespace GameSotre.Api.Endpoints;

public static class GamesEndpoints
{
	public const string ENDPOINT_GET_GAME = "GetGame";


	public static void MapGamesEndpoints(this WebApplication app)
	{
		var gamesGroup = app.MapGroup("games");

		// --------------------------------------------------
		// GET /games
		gamesGroup.MapGet("/", (IGameService gameService) =>
		{
			return Results.Ok(gameService
				.Getall()
				.Select(game => game.ToGameSummaryDto()));
		});

		// --------------------------------------------------
		// GET /games/1
		gamesGroup.MapGet("/{id}", (int id, IGameService gameService) =>
		{
			var game = gameService.GetById(id);
			if (null == game)
			{
				return Results.NotFound();
			}

			return Results.Ok(game.ToGameDetailsDto());
		})
		// .WithName defines a name for the endpoint
		.WithName(ENDPOINT_GET_GAME);

		// --------------------------------------------------
		// POST /games
		gamesGroup.MapPost("/", (CreateGameDto createGameDto, IGameService gameService) =>
		{
			var game = createGameDto.ToGame();

			gameService.Upsert(game);

			// get fresh load of game inculding genre-data
			game = gameService.GetById(game.Id)!;

			return Results.CreatedAtRoute(
				ENDPOINT_GET_GAME,
				new { id = game.Id },
				game.ToGameSummaryDto());
		});

		// --------------------------------------------------
		// PUT /games/1
		gamesGroup.MapPut("/{id}", (int id, UpdateGameDto updateGameDto, IGameService gameService) =>
		{
			var existingGame = gameService.GetById(id);
			if (null == existingGame)
			{
				// tutor prefers to not do and "upsert" but rather return notFound
				// becuase dB with autoIncrementing ids create confusion when adding a new object
				// with a different Id when an upsert call is executed with a specific Id.
				return Results.NotFound();
			}

			var updatedGame = updateGameDto.ToGame(id);

			gameService.Upsert(updatedGame);

			return Results.NoContent();
		});

		// --------------------------------------------------
		// DELETE /games/1
		gamesGroup.MapDelete("/{id}", (int id, IGameService gameService) =>
		{
			gameService.Delete(id);

			return Results.NoContent();
		});


		// --------------------------------------------------
		// DELETE /games?ids=1,2,3
		gamesGroup.MapDelete("/", ([FromQuery(Name = nameof(ids))] string ids, IGameService gameService) =>
		{
			var idsList = ids.Split(",")
				.Select(id => int.TryParse(id, out var parsedId) ? parsedId : (int?)null)
				.Where(parsedId => parsedId.HasValue)
				.Cast<int>()
				.ToList();

			gameService.DelteMany(idsList);

			return Results.NoContent();
		});
	}
}
