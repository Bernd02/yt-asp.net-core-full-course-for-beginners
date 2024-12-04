using GameStore.Data.Models;

namespace GameStore.Services.GenreService;

public interface IGenreService
{
	Genre? GetById(int id);
}
