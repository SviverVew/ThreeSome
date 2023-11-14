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
        public ActionResult Gerne(int GenreID)
        {
            var Ger = db.genres.FirstOrDefault(x => x.genreID == GenreID);

            if (Ger.genreID!= GenreID)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Film> filmm = db.Films.Where(x => x.filmGenre == GenreID).ToList();
            var filModel = filmm.Select(
                x => new FilmModel
                {
                   FilmTitle=x.filmTitle,
                   FilmDes=x.filmDes,
                   FilmImg=x.filmIMG,
                   FilmCount=x.filmEsp,
                    FilmID = x.filmID,
                    FilmLink = x.filmLink,
                }
                ).ToList();
            // Gán thông tin của bộ phim cho phần tử đầu tiên trong VidModel

            if (filModel.Any())
            {
                filModel.First().GerneId = Ger.genreID;
                filModel.First().GerneName = Ger.genreName;
            }
           
            return View(filModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}