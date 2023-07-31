using Microsoft.AspNetCore.Mvc;
using Music.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    public SongController()
    { }

    [HttpGet]
    public ActionResult<IEnumerable<Song>> GetAllSongs(MusicDbContext db)
    {
        return db.Songs.ToList();
    }

    [HttpPost]
    public ActionResult<IEnumerable<Song>> AddSongs(MusicDbContext db, Song[] songs)
    {
        db.Songs.AddRange(songs);
        db.SaveChanges();
        return db.Songs.ToList();
    }

    [HttpPatch]
    public ActionResult<IEnumerable<Song>> ChangeSongs(MusicDbContext db, Song[] songs)
    {
        foreach (Song song in songs)
        {
            Song? fromDb = db.Songs.First(v => v.id == song.id);
            if (fromDb is not null)
            {
                fromDb.name = song.name;
                fromDb.song = song.song;
                fromDb.album = song.album;
                fromDb.artist = song.artist;
            }
        }
        db.SaveChanges();
        return db.Songs.ToList();
    }

    [HttpDelete]
    public ActionResult<IEnumerable<Song>> DeleteSongs(MusicDbContext db, string[] ids)
    {
        foreach (string id in ids)
        {
            Song? fromDb = db.Songs.First(v => v.id == id);
            if (fromDb is not null)
            {
                db.Songs.Remove(fromDb);
            }
        }
        db.SaveChanges();
        return db.Songs.ToList();
    }
}