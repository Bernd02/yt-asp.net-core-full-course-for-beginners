using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.DbConfigurations;

internal class GenreEntityTypeConfig : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		// seeding
		// add a new migration to actually seed this data
		builder.HasData(new List<Genre>() {
			new Genre() { Id = 1, Name = "Fighting" },
			new Genre() { Id = 2, Name = "Role playing" },
			new Genre() { Id = 3, Name = "Sports" },
			new Genre() { Id = 4, Name = "Racing" },
			new Genre() { Id = 5, Name = "Kids and Family" },
		});
	}
}
