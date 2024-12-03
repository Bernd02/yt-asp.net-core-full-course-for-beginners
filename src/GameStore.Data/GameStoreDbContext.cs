using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : DbContext(options)
{
	public DbSet<Game> Games => Set<Game>();
	public DbSet<Genre> Genres => Set<Genre>();



}
