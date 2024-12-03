using GameStore.Data.Models;

namespace GameStore.Data.Repos;

internal interface IGameRepo
{
	List<Game> Getall();
	Game Get(int id);
	void Upsert(Game game);
	bool Delete(int id);
}
