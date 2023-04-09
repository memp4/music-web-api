namespace Music.Models;

public class PlaylistConstants
{
    public static List<Playlist> all = new List<Playlist>() { playlist1 };
    public static Playlist playlist1 = new Playlist()
    {
        id = "playlist1",
        name = "First playlist",
        songs = new List<Song>()
        {
            SongConstants.song1, SongConstants.song4, SongConstants.song7, SongConstants.song9
        }
    };
}