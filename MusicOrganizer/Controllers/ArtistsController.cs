using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectArtist = Artist.Find(id);
      List<Album> artistAlbums = selectArtist.Albums;
      model.Add("artist", selectArtist);
      model.Add("albums", artistAlbums);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/albums")]
    public ActionResult Create(int artistId, string albumName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Album newAlbum = new Album(albumName);
      foundArtist.AddAlbum(newAlbum);
      List<Album> artistAlbums = foundArtist.Albums;
      model.Add("albums", artistAlbums);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

    [HttpPost("/artists/delete")]
    public ActionResult DeleteAll()
    {
      Artist.ClearAll();
      return RedirectToAction("Index");
    }
  }
}