namespace GameSotre.Api.Dtos.Game;

public record GameSummaryDto(
	int Id,
	string Name,
	string Genre,
	decimal Price,
	DateOnly ReleaseDate);
