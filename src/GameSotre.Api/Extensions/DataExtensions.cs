using GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GameSotre.Api.Extensions;

public static class DataExtensions
{
	/// <summary>
	/// Method for migrating db on startup.
	/// </summary>
	public static void MigrateDb(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
		dbContext.Database.Migrate();
	}
}
