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
	public async Task<List<Game>> GetallAsync()
	{
		var games = await _dbContext.Games
			.Include(g => g.Genre)
			.AsNoTracking()
			.ToListAsync();

		return games;
	}

	public async Task<Game?> GetByIdAsync(int id)
	{
		var game = await _dbContext.Games
			.Include(game => game.Genre)
			.SingleOrDefaultAsync(game => game.Id == id);

		return game;
	}

	public async Task UpsertAsync(Game game)
	{
		var existingGame = await _dbContext.Games.FindAsync(game.Id);
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

		await _dbContext.SaveChangesAsync();
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var deleteCount = await _dbContext.Games
			.Where(game => game.Id == id)
			.ExecuteDeleteAsync();

		return deleteCount == 0 ? false : true;
	}

	public async Task DelteManyAsync(List<int> ids)
	{
		await _dbContext.Games
			.Where(game => ids.Contains(game.Id))
			.ExecuteDeleteAsync();
	}
}
