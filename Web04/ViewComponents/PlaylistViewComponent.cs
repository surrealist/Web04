using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web04.Models;

namespace Web04.ViewComponents {
  public class PlaylistViewComponent : ViewComponent {

    public IViewComponentResult Invoke(Playlist playlist) {
      return View(playlist);
    }

  }
}
