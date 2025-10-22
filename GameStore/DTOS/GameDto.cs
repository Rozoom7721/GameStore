namespace GameStore.DTOS;

public record class GameDto(
    int Id,
    string Title,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate)
{

}
