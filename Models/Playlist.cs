namespace Music.Models;

public class Playlist
{
    public string? id { get; set; }
    public string? name { get; set; }
    public List<Song>? songs { get; set; }
}