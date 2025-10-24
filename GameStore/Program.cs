using GameStore.Data;
using GameStore.DTOS;
using GameStore.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontedn", policy =>
    {
        policy.WithOrigins("http://localhost:4173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenerEndpoints();

app.UseCors("AllowFrontedn");

await app.MigrateDbAsync();

app.Run();
