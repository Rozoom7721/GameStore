namespace GameStore.DTOS;

public record class CreateGameDto (
    string Title,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate)
{

}
