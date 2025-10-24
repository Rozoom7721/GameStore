using System;
using GameStore.Data;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GenerEndpoints
{

    public static RouteGroupBuilder MapGenerEndpoints (this WebApplication app)
    {
        var group = app.MapGroup("geners");

        group.MapGet("/", async (GameStoreContext dbcontext) =>
        await dbcontext.Geners
            .Select(gener => gener.ToGenerDto())
            .AsNoTracking()
            .ToListAsync());

        return group;
    }
}
