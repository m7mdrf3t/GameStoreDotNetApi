
using GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DataMigration;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app){
        using var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}