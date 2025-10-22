using GameStore.DTOS;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new GameDto(1, "The Witcher 3", "RPG", 29.99m, new DateOnly(2015, 5, 19)),
    new GameDto(2, "Cyberpunk 2077", "Action RPG", 59.99m, new DateOnly(2020, 12, 10)),
    new GameDto(3, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18))
];
//Get /games
app.MapGet("games", () => games);

//Get /games/{id}
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
.WithName(GetGameEndpointName);

//POST /games

app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto gameToAdd = new(
        games.Count + 1,
        newGame.Title,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
        );
    games.Add(gameToAdd);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameToAdd.Id }, gameToAdd);
});

//PUT /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var gameIndex = games.FindIndex(game => game.Id == id);

    games[gameIndex] = new GameDto(
        id,
        updatedGame.Title,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );
    return Results.NoContent();
});

app.MapGet("/", () => "Hello World!");

app.Run();
