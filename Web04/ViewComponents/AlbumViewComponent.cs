using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web04.Data;

namespace Web04.ViewComponents {
  public class AlbumViewComponent : ViewComponent {

    public AlbumViewComponent(ApplicationDbContext db) {
      Db = db;
    }

    public ApplicationDbContext Db { get; }

    public async Task<IViewComponentResult> InvokeAsync(int albumId) {
      var album = await Db.Albums.FindAsync(albumId);
      return View(album);
    }
  }
}
