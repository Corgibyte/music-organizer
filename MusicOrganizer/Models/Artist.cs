using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist>() { };
    public string Name { get; set; }
    public int Id { get; }
    public List<Album> Albums { get; }

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
      Albums = new List<Album>() { };
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artist Find(int id)
    {
      return _instances[id - 1];
    }

    public void AddAlbum(Album album)
    {
      Albums.Add(album);
    }
  }
}