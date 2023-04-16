using Microsoft.AspNetCore.Mvc;
using Music.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaylistController : ControllerBase
{
    public PlaylistController()
    { }

    [HttpGet]
    public IActionResult GetAllPlaylists()
    {
        return Ok(PlaylistConstants.all);
    }

    [HttpGet("{plalistId}")]
    public IActionResult GetPlaylist(string plalistId)
    {
        Playlist? playlist = PlaylistConstants.all.Find(playlist => playlist.id == plalistId);

        if (playlist is null)
        {
            return NotFound();
        }

        return Ok(playlist);
    }

    [HttpPost]
    public IActionResult CreateNewPlaylist(string playlistName, string[] songs)
    {
        string newId = Guid.NewGuid().ToString("N");
        List<Song> addSongs = new List<Song>();
        foreach (string song in songs)
        {
            Song? toAdd = SongConstants.all.Find(s => s.name == song);
            if (toAdd is not null)
            {
                addSongs.Add(toAdd);
            }
        }

        Playlist newPlaylist = new Playlist()
        {
            id = newId,
            name = playlistName,
            songs = addSongs
        };

        PlaylistConstants.all.Add(newPlaylist);

        return Ok(PlaylistConstants.all);
    }
}
