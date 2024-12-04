using GameStore.Data.Models;

namespace GameStore.Services.GameService;

public interface IGameService
{
	List<Game> Getall();
	Game? GetById(int id);
	void Upsert(Game game);
	bool Delete(int id);
	void DelteMany(List<int> ids);
}
