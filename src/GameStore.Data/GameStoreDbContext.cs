using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : DbContext(options)
{
	public DbSet<Game> Games => Set<Game>();
	public DbSet<Genre> Genres => Set<Genre>();


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// seeding
		// add a new migration to actually seed this data
		modelBuilder.Entity<Genre>().HasData(new List<Genre>() {
			new() { Id = 1, Name = "Fighting" },
			new() { Id = 2, Name = "Role playing" },
			new() { Id = 3, Name = "Sports" },
			new() { Id = 4, Name = "Racing" },
			new() { Id = 5, Name = "Kids and Family" },
		});
	}
}
