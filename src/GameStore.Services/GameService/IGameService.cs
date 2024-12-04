using GameStore.Data.Models;

namespace GameStore.Services.GameService;

public interface IGameService
{
	Task<List<Game>> GetallAsync();
	Task<Game?> GetByIdAsync(int id);
	Task UpsertAsync(Game game);
	Task<bool> DeleteAsync(int id);
	Task DelteManyAsync(List<int> ids);
}
