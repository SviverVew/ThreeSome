using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class HomeController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Index()
        {
            List<Film> FilmList = db.Films.ToList();
            var filmModel = FilmList.Select(
                x => new FilmModel
                {
                    FilmID = x.filmID,
                    FilmTitle = x.filmTitle,
                    FilmDes = x.filmDes,
                    FilmImg = x.filmIMG,
                }
                ).ToList();
            return View(filmModel);
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Trending()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}