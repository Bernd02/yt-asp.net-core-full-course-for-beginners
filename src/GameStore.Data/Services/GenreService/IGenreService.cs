using GameStore.Data.Models;

namespace GameStore.Data.Services.GenreService;

public interface IGenreService
{
	Genre? GetById(int id);
}
