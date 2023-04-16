namespace Music.Models;

public class PlaylistConstants
{
    public static Playlist playlist1 = new Playlist()
    {
        id = "playlist1",
        name = "First playlist",
        songs = new List<Song>()
        {
            SongConstants.song1, SongConstants.song4, SongConstants.song7, SongConstants.song9
        }
    };

    public static Playlist playlist2 = new Playlist()
    {
        id = "playlist2",
        name = "Second playlist",
        songs = new List<Song>()
        {
            SongConstants.song2, SongConstants.song6, SongConstants.song5, SongConstants.song8
        }
    };
    public static List<Playlist> all = new List<Playlist>() { playlist1, playlist2 };
}