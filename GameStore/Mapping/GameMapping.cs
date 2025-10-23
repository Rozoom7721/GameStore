using System;
using GameStore.DTOS;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game
        {
            Title = game.Title,
            GenerId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new GameSummaryDto(
            game.Id,
            game.Title,
            game.Gener!.Name,
            game.Price,
            game.ReleaseDate
        );
    }
    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new GameDetailsDto(
            game.Id,
            game.Title,
            game.GenerId,
            game.Price,
            game.ReleaseDate
        );
    }
        public static Game ToEntity(this UpdateGameDto game, int id)
    {
        return new Game
        {
            Id = id,
            Title = game.Title,
            GenerId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
}

