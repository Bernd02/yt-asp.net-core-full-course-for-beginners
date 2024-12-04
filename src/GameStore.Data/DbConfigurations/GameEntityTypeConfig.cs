using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.DbConfigurations;
internal class GameEntityTypeConfig : IEntityTypeConfiguration<Game>
{
	public void Configure(EntityTypeBuilder<Game> builder)
	{
		builder.HasData(new List<Game>()
		{
			new Game() {
				Id = 1,
				Name = "Street Fighter II",
				GenreId = 1,
				Price = 19.99m,
				ReleaseDate = new DateOnly(1992, 7, 15)
			},
			new Game() {
				Id = 2,
				Name = "Final Fantasy XIV",
				GenreId = 2,
				Price = 59.99m,
				ReleaseDate = new DateOnly(2010, 9, 30)
			},
			new Game() {
				Id = 3,
				Name = "FIFA 23",
				GenreId = 3,
				Price = 69.99m,
				ReleaseDate = new DateOnly(2022, 9, 27)
			},
		});
	}
}
