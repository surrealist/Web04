using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Web04.Models;
using Web04.Data;
using Microsoft.AspNetCore.Identity;
using Web04.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Web04.Controllers {

  public class PlaylistsController : Controller {

    private readonly ApplicationDbContext db;
    private readonly UserManager<ApplicationUser> userManager;

    public PlaylistsController(ApplicationDbContext db,
        UserManager<ApplicationUser> userManager) {
      this.db = db;
      this.userManager = userManager;
    }

    [Authorize]
    public IActionResult Index() {
      return View();
    }

    [HttpGet]
    [Route("/api/v1/playlists")]
    public async Task<IActionResult> GetAll() {
      if (string.IsNullOrEmpty(User.Identity.Name)) {
        return Unauthorized();
        //return BadRequest();
      }
       
      var user = await userManager.FindByEmailAsync(User.Identity.Name);
      if (user == null) {
        return Json(Enumerable.Empty<PlaylistDTO>());
      }

      var q = from pl in db.Playlists
              where pl.Owner == user
              select new PlaylistDTO {
                Id = pl.Id,
                Name = pl.Name
              };

      return Json(q.ToList());
    }

    [HttpPost]
    [Route("/api/v1/playlists/{playlistId}/items")]
    public async Task<IActionResult> PostMusicItemIntoPlaylist(int playlistId, int itemId) {
      var user = await userManager.FindByEmailAsync(User.Identity.Name);
      if (user == null) {
        return Unauthorized();
      }

      var playlist = await (from pl in db.Playlists
                     where pl.Owner == user
                     && pl.Id == playlistId
                     select pl).SingleOrDefaultAsync();
      if (playlist == null) {
        return NotFound();
      }

      var item = await db.MusicItems.FindAsync(itemId);
      if (item == null) {
        return NotFound();
      }

      var mapping = new PlaylistMusicItem();
      mapping.Playlist = playlist;
      mapping.MusicItem = item;
      playlist.Items.Add(mapping);

      await db.SaveChangesAsync();
      return Created($"/api/v1/Playlists/{playlistId}/items/{mapping.Id}", mapping);
    }
  }
}