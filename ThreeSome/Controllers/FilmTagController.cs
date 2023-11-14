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
                    FilmCount=x.SumEspisode
                }
                ).ToList();
            return View(filmModel);
        }
        public ActionResult FilmDetail(int FilmID)
        {
            
            var film = db.Films.FirstOrDefault(x => x.filmID == FilmID);
            if (film.filmID != FilmID)
            {
                return RedirectToAction("Index","Home") ;
            }
            List<espisode> espisodes = db.espisodes.Where(x => x.film_ID == FilmID).ToList();
            var VidModel = espisodes.Select(
                x => new FilmModel
                {
                    VidTitle = $"{x.Film.filmTitle}: Tập {x.Espisode1}",
                    VidIMG= x.vidIMG,
                    VidId=x.vidID,
                }
                ).ToList();
            // Gán thông tin của bộ phim cho phần tử đầu tiên trong VidModel

            if (VidModel.Any())
            {
            VidModel.First().FilmID = film.filmID;
            VidModel.First().FilmImg = film.filmIMG;
            VidModel.First().FilmTitle = film.filmTitle;
            VidModel.First().FilmDes = film.filmDes;
            }
            return View(VidModel);

        }
        public ActionResult WatchMovie(int VidID)
        {
            // Tìm video dựa trên VidID
            var vid = db.espisodes.FirstOrDefault(x => x.vidID == VidID);
            // Lấy thông tin bộ phim từ video
            var Filmss = vid.film_ID;
            var film = db.Films.FirstOrDefault(x => x.filmID == Filmss);
            // Tạo một đối tượng VidModel và gán thông tin của video và bộ phim cho nó
            var VidModel = new FilmModel
            {
                VidTitle = $"{film.filmTitle}: Tập {vid.Espisode1}",
                VidIMG = vid.vidIMG,
                VidAddress = vid.vidAddress,
                VidId = vid.vidID,
                FilmImg = film.filmIMG,
                FilmTitle = film.filmTitle,
                FilmDes = film.filmDes,
                FilmID=film.filmID
            };
            // Tìm các tập phim liên quan có cùng film_ID với bộ phim
            ViewBag.Episodes = db.espisodes.Where(x => x.film_ID == Filmss).ToList();
            return View(VidModel);
        }
    }
}