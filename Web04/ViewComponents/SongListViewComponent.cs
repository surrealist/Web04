using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web04.Data;

namespace Web04.ViewComponents {
  public class SongListViewComponent : ViewComponent {

    public SongListViewComponent(ApplicationDbContext db) {
      Db = db;
    }

    public ApplicationDbContext Db { get; }

    public async Task<IViewComponentResult> InvokeAsync(int albumId) {
      var album = Db.Albums.Find(albumId);
      await Db.Entry(album).Collection(x => x.Songs).LoadAsync();
      // await Db.Entry(album).Reference(x => x.SongWriter).LoadAsync();

      return View(album.Songs.ToList());
    }

  }
}
