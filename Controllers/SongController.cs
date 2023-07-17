using Microsoft.AspNetCore.Mvc;
using Music.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    public SongController()
    { }

    [HttpGet("{name}")]
    public async Task<ActionResult> DownloadSong(string name)
    {
        string filePath = $"Assets/{name}.mp3";

        try
        {
            byte[] bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "audio/mpeg", Path.GetFileName(filePath));
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Song>> GetAllSongs(MusicDbContext db)
    {
        return db.Song.ToList();
    }

    // [HttpGet("{name}")]
    // public ActionResult<IEnumerable<Song>> GetSong(string name, MusicDbContext db)
    // {
    //     Song? result = db.Song.First(song => song.name == name);
    //     if (result is null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(result);
    // }
}