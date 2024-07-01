using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext>option) : base(option){

    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<Studio> Studios => Set<Studio>();

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Game>().
        // HasOne(g => g.Genre).WithMany(ge => ge.Games).HasForeignKey(g => g.genreID);
        

        modelBuilder.Entity<Genre>().HasData(
            new {id = 1 , name = "Fighting"},
            new {id = 2 , name = "RolePlaying"},
            new {id = 3 , name = "Sports"},
            new {id = 4 , name = "Racing"},
            new {id = 5 , name = "Kids & Family"},
            new {id = 6 , name = "Cards"}
        );

        base.OnModelCreating(modelBuilder);
    }

}