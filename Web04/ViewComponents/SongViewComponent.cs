using Microsoft.AspNetCore.Mvc; 
using Web04.Models;

namespace Web04.ViewComponents {
  public class SongViewComponent : ViewComponent {

    public IViewComponentResult Invoke(Song song) {
      return View(song);
    }
  }
}
