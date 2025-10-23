namespace GameStore.DTOS;

public record class GameSummaryDto(
    int Id,
    string Title,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);
