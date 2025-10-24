namespace GameStore.DTOS;

public record class GameDetailsDto(
    int Id,
    string Title,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate);

