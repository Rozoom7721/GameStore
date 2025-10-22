using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOS;

public record class CreateGameDto (
    [Required][StringLength(50)]string Title,
    int GenreId,
    [Required]decimal Price,
    [Required]DateOnly ReleaseDate)
{

}
