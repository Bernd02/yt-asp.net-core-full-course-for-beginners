using GameStore.Data.Models;

namespace GameStore.Data.Repos;

internal class StaticInMemoryGameRepo : IGameRepo
{
	private static readonly List<Game> games = new List<Game>()
	{
		//new Game {1, "Street Fighter II", "Fighting", 19.99m, new DateOnly(1992, 7, 15)},
		//new Game {2, "Final Fantasy XIV", "Role playing", 59.99m, new DateOnly(2010, 9, 30)},
		//new Game {3, "FIFA 23", "Sports", 69.99m, new DateOnly(2022, 9, 27) },
	};


	public List<Game> Getall()
	{
		return games;
	}

	public Game? Get(int id)
	{
		var game = games.Find(game => game.Id == id);
		return game;
	}

	public void Upsert(Game game)
	{
		var index = games.IndexOf(game);
		if (index == -1)
		{
			games.Add(game);
		}
		else
		{
			games[index] = game;
		}
	}

	public bool Delete(int id)
	{
		var toBeRemoved = games.FirstOrDefault(game => game.Id == id);
		if (null == toBeRemoved)
		{
			return false;
		}
		games.Remove(toBeRemoved);
		return true;
	}
}
