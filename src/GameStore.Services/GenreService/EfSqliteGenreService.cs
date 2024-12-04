using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Services.GenreService;

public class EfSqliteGenreService : IGenreService
{
	private readonly GameStoreDbContext _dbContext;


	public EfSqliteGenreService(GameStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}


	public Task<List<Genre>> GetAllAsync()
	{
		var allGenres = _dbContext.Genres
			.AsNoTracking()
			.ToListAsync();

		return allGenres;
	}

	public async Task<Genre?> GetByIdAsync(int id)
	{
		var genre = await _dbContext.Genres.FindAsync(id);
		return genre;
	}
}
