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
}
