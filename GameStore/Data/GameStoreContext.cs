using System;
using System.Data.Common;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
: DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Gener> Geners => Set<Gener>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gener>().HasData(
            new { Id = 1, Name = "Action" },
            new { Id = 2, Name = "Adventure" },
            new { Id = 3, Name = "RPG" },
            new { Id = 4, Name = "Strategy" },
            new { Id = 5, Name = "Simulation" },
            new { Id = 6, Name = "Sports" },
            new { Id = 7, Name = "Puzzle" },
            new { Id = 8, Name = "Sandbox" }
        );
    }
}
