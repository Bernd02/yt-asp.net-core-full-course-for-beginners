using GameStore.Data;
using GameStore.Data.Models;

namespace GameStore.Services.GenreService;

public class EfSqliteGenreService : IGenreService
{
	private readonly GameStoreDbContext _dbContext;


	public EfSqliteGenreService(GameStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}


	public Genre? GetById(int id)
	{
		var genre = _dbContext.Genres.Find(id);
		return genre;
	}
}
