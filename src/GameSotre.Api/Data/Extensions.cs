using GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GameSotre.Api.Data;

public static class Extensions
{
	/// <summary>
	/// Method for migrating db on startup.
	/// </summary>
	public static void MigrateDb(this WebApplication app)
	{
		var scope = app.Services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
		dbContext.Database.Migrate();
	}
}
