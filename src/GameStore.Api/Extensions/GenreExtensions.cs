using GameSotre.Api.Dtos.Genre;
using GameStore.Data.Models;

namespace GameSotre.Api.Extensions;

public static class GenreExtensions
{
	public static GenreDto ToGenreDto(this Genre genre)
	{
		return new GenreDto(
			genre.Id,
			genre.Name);
	}
}
