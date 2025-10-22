using System;
using GameStore.Data;
using GameStore.DTOS;
using GameStore.Entities;

namespace GameStore.EndPoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
    new GameDto(1, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDto(2, "Cyberpunk 2077", "Action RPG", 59.99m, new DateOnly(2020, 12, 10)),
    new GameDto(3, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18))
];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
                    .WithParameterValidation();
        //GET /games
        group.MapGet("/", () => games);

        //GET /games/{id}
        group.MapGet("/{id}", (int id) =>
            {
                GameDto? game = games.Find(game => game.Id == id);

                return game is null ? Results.NotFound() : Results.Ok(game);
            })
        .WithName(GetGameEndpointName);

        //POST /games

        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game gameToAdd = new()
            {
                Title = newGame.Title,
                Gener = dbContext.Geners.Find(newGame.GenreId),
                GenerId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };
            dbContext.Games.Add(gameToAdd);
            dbContext.SaveChanges();

            GameDto gameDto = new(
                gameToAdd.Id,
                gameToAdd.Title,
                gameToAdd.Gener!.Name,
                gameToAdd.Price,
                gameToAdd.ReleaseDate
            );

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameToAdd.Id }, gameDto);
        });

        //PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var gameIndex = games.FindIndex(game => game.Id == id);

            if (gameIndex == -1)
            {
                return Results.NotFound();
            }

            games[gameIndex] = new GameDto(
                id,
                updatedGame.Title,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );
            return Results.NoContent();
        });

        //Delete /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            var gameIndex = games.FindIndex(game => game.Id == id);
            games.RemoveAt(gameIndex);
            return Results.NoContent();
        });
        return group;
    }
}
