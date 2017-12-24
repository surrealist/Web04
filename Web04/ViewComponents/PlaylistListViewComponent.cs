using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Web04.Data;
using Web04.Models;

namespace Web04.ViewComponents {

  public class PlaylistListViewComponent : ViewComponent {

    private readonly ApplicationDbContext db;
    private readonly UserManager<ApplicationUser> userManager;

    public PlaylistListViewComponent(ApplicationDbContext db,
        UserManager<ApplicationUser> userManager) {
      this.db = db;
      this.userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync() {
      var currentUser = await userManager.FindByEmailAsync(User.Identity.Name);

      var q = from p in db.Playlists
              where p.Owner == currentUser
              select p;

      var items = await q.ToListAsync();
      foreach (var item in items) {
        await db.Entry(item).Collection(x => x.Items).LoadAsync();
        foreach (var musicItem in item.Items) {
          await db.Entry(musicItem).Reference(x => x.MusicItem).LoadAsync();
        }
      }
      return View(await q.ToListAsync());
    }
  }
}
