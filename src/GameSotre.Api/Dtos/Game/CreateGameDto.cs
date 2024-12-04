namespace GameSotre.Api.Dtos.Game;

public record CreateGameDto(
	string Name,
	int GenreId,
	decimal Price,
	DateOnly ReleaseDate);
