namespace GameStore.DTOS;

public record class UpdateGameDto(
    string Title,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
)
{

}
