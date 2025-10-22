using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOS;

public record class CreateGameDto (
    [Required][StringLength(50)]string Title,
    [Required][StringLength(20)]string Genre,
    [Required]decimal Price,
    [Required]DateOnly ReleaseDate)
{

}
