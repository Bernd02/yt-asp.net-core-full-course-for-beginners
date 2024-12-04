using GameStore.Data.Models;

namespace GameStore.Services.GenreService;

public interface IGenreService
{
	Task<Genre?> GetByIdAsync(int id);
	Task<List<Genre>> GetAllAsync();
}
