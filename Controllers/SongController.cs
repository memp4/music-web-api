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
        return db.Song.ToList();
    }

    [HttpPost]
    public ActionResult<IEnumerable<Song>> AddSongs(MusicDbContext db, Song[] songs)
    {
        db.Song.AddRange(songs);
        db.SaveChanges();
        return db.Song.ToList();
    }

    [HttpPatch]
    public ActionResult<IEnumerable<Song>> ChangeSongs(MusicDbContext db, Song[] songs)
    {
        foreach (Song song in songs)
        {
            Song? fromDb = db.Song.First(v => v.id == song.id);
            if (fromDb is not null)
            {
                fromDb.name = song.name;
                fromDb.song = song.song;
                fromDb.album = song.album;
                fromDb.artist = song.artist;
            }
        }
        db.SaveChanges();
        return db.Song.ToList();
    }

    [HttpDelete]
    public ActionResult<IEnumerable<Song>> DeleteSongs(MusicDbContext db, string[] ids)
    {
        foreach (string id in ids)
        {
            Song? fromDb = db.Song.First(v => v.id == id);
            if (fromDb is not null)
            {
                db.Song.Remove(fromDb);
            }
        }
        db.SaveChanges();
        return db.Song.ToList();
    }
}