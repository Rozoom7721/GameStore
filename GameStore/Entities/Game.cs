using System;

namespace GameStore.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int GenerId { get; set; }
    public Gener? Gener { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
