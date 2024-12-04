﻿namespace GameSotre.Api.Dtos;

public record UpdateGameDto(
	string Name,
	int GenreId,
	decimal Price,
	DateOnly ReleaseDate);
