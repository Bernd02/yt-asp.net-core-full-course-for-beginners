using GameSotre.Api.Dtos;
using GameStore.Data.Models;

namespace GameSotre.Api.Extensions;

public static class GameMappingExtensions
{
	public static Game ToGame(this CreateGameDto createGameDto)
	{
		return new Game()
		{
			Name = createGameDto.Name,
			GenreId = createGameDto.GenreId,
			Price = createGameDto.Price,
			ReleaseDate = createGameDto.ReleaseDate,
		};
	}

	public static Game ToGame(this UpdateGameDto updateGameDto, int gameId)
	{
		return new Game()
		{
			Id = gameId,
			Name = updateGameDto.Name,
			GenreId = updateGameDto.GenreId,
			Price = updateGameDto.Price,
			ReleaseDate = updateGameDto.ReleaseDate,
		};
	}

	public static GameSummaryDto ToGameSummaryDto(this Game game)
	{
		return new GameSummaryDto(
			game.Id,
			game.Name,
			game.Genre?.Name,
			game.Price,
			game.ReleaseDate);
	}

	public static GameDetailsDto ToGameDetailsDto(this Game game)
	{
		return new GameDetailsDto(
			game.Id,
			game.Name,
			game.GenreId,
			game.Price,
			game.ReleaseDate);
	}
}
