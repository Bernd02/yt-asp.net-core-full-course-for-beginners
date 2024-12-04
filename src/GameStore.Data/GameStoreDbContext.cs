using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : DbContext(options)
{
	public DbSet<Game> Games => Set<Game>();
	public DbSet<Genre> Genres => Set<Genre>();


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// add a new migration to actually add new configurations
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameStoreDbContext).Assembly);
	}
}
