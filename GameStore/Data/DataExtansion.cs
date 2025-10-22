using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public static class DataExtansion
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbcontext.Database.Migrate();
    }
}
