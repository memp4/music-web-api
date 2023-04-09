using Microsoft.AspNetCore.Mvc;

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
}