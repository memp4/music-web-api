using Microsoft.EntityFrameworkCore;
using Music.Models;
using UserSpace.Models;

public class MusicDbContext : DbContext
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<UserModel> Users { get; set; }
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
        modelBuilder.Entity<Playlist>().HasData(
        new Playlist()
        {
            id = "playlist1",
            name = "First playlist",
            songs = new List<Song>()
            {
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
            }
        },
        new Playlist()
        {
            id = "playlist2",
            name = "Second playlist",
            songs = new List<Song>()
            {
                new Song()
                {
                    id = "song3",
                    name = "bee.",
                    song = "bee",
                    album = "bee.",
                    artist = "Groove music"
                },
                new Song()
                {
                    id = "song4",
                    name = "Puffin on Zooties",
                    song = "Future - PUFFIN ON ZOOTIEZ (Official Audio)",
                    album = "I Never Liked You",
                    artist = "Future"
                }
            }
        }
        );
        // modelBuilder.Entity<UserModel>().HasData();
    }
}