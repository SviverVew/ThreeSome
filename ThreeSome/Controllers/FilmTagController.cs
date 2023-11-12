using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    
    public class FilmTagController : Controller
    {
        WEBEntitiesEntities db=new WEBEntitiesEntities();
        // GET: FilmTag
        public ActionResult FilmList()
        {
            List<Film> FilmList = db.Films.ToList();
            var filmModel = FilmList.Select(
                x => new FilmModel
                {
                    FilmID=x.filmID,
                    FilmTitle=x.filmTitle,
                    FilmDes=x.filmDes,
                    FilmImg=x.filmIMG,
                }
                ).ToList();
            return View(filmModel);
        }
        public ActionResult FilmDetail(int FilmID)
        {
            var film = db.Films.FirstOrDefault(x => x.filmID == FilmID);
           
            if (film == null)
            {
                return View(ViewBag.ErrorLog = "Phim chuẩn bị phát hành") ;
            }

            List<espisode> espisodes = db.espisodes.Where(x => x.film_ID == FilmID).ToList();
            var VidModel = espisodes.Select(
                x => new FilmModel
                {
                    VidTitle = $"{x.Film.filmTitle}: Tập {x.vidID}",
                    VidIMG= x.vidIMG,
                }
                ).ToList();
            // Gán thông tin của bộ phim cho phần tử đầu tiên trong VidModel

            if (VidModel.Any())
            {
                VidModel.First().FilmImg = film.filmIMG;
            VidModel.First().FilmTitle = film.filmTitle;
            VidModel.First().FilmDes = film.filmDes;
            }
            return View(VidModel);

        }
    }
}