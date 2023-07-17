using Microsoft.EntityFrameworkCore;
using Music.Models;

public class MusicDbContext : DbContext
{
    public DbSet<Song> Song { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Music.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().HasData(
            new Song()
            {
                id = "song1",
                name = "Rap Saved Me",
                song = "21 Savage, Offset & Metro Boomin -  Rap Saved Me  Ft Quavo (Official Audio)",
                album = "Without Warning",
                artist = "Metro Boomin"
            },
            new Song()
            {
                id = "song2",
                name = "Trilla",
                song = "A$AP Rocky - Trilla (Ft. A$AP Twelvy & A$AP Nast) [LiveLoveAsap]",
                album = "Live.Love.A$AP",
                artist = "A$AP Rocky"
            }
        );
    }
}