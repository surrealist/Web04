using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web04.Models;
using Web04.Data;

namespace Web04.Controllers {
  public class HomeController : Controller {

    public ApplicationDbContext Db { get; }

    public HomeController(ApplicationDbContext db) {
      Db = db;
    }

    public IActionResult Index() {
      var albums = Db.Albums.ToList();
      return View(albums);
    }

    public IActionResult About() {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact() {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    public IActionResult Error() {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
