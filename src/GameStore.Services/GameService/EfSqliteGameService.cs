using GameStore.Data;
using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Services.GameService;

public class EfSqliteGameService : IGameService
{
	private readonly GameStoreDbContext _dbContext;


	public EfSqliteGameService(GameStoreDbContext dbContext)
	{
		_dbContext = dbContext;
	}


	/// <summary>
	/// Get all entities AsNoTracking.
	/// </summary>
	public List<Game> Getall()
	{
		var games = _dbContext.Games
			.Include(g => g.Genre)
			.AsNoTracking()
			.ToList();

		return games;
	}

	public Game? GetById(int id)
	{
		var game = _dbContext.Games
			.Include(game => game.Genre)
			.SingleOrDefault(game => game.Id == id);

		return game;
	}

	public void Upsert(Game game)
	{
		var existingGame = _dbContext.Games.Find(game.Id);
		if (null == existingGame)
		{
			_dbContext.Games.Add(game);
		}
		else
		{
			// solve tracking issues with .CurrentValues.SetValues()
			// ... finding the existing game adds it to tracking
			// ... .Update() would try to add it to tracking a second time > resulting in an error.
			_dbContext.Entry(existingGame)
				.CurrentValues
				.SetValues(game);
		}

		_dbContext.SaveChanges();
	}

	public bool Delete(int id)
	{
		var deleteCount = _dbContext.Games
				.Where(game => game.Id == id)
				.ExecuteDelete();

		_dbContext.SaveChanges();

		return deleteCount == 0 ? false : true;
	}

	public void DelteMany(List<int> ids)
	{
		_dbContext.Games
			.Where(game => ids.Contains(game.Id))
			.ExecuteDelete();

		_dbContext.SaveChanges();
	}
}
