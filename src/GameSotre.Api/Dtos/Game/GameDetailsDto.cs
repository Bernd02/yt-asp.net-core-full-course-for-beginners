namespace GameSotre.Api.Dtos.Game;

public record GameDetailsDto(
	int Id,
	string Name,
	int GenreId,
	decimal Price,
	DateOnly ReleaseDate);
