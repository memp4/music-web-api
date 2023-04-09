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
        return Ok(PlaylistConstants.playlist1);
    }
}
