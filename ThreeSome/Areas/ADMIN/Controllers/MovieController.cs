using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;
using System.Data.Entity.Validation;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class MovieController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: ADMIN/Movie
        public ActionResult Movie()
        {
            return View(db.Films.ToList());
        }

        #region "TAO MOI"
        [HttpGet]
        public ActionResult Create()
        {
            Film film = new Film();
            return View(film);
        }
        [HttpPost]
        public ActionResult Create(Film film)
        {
            try
            {
                if (film.IMGupload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(film.IMGupload.FileName);
                    string extension = Path.GetExtension(film.IMGupload.FileName);
                    fileName = fileName + extension;
                    film.filmIMG = "~/Content/Img/" + fileName;
                    film.IMGupload.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), fileName));
                }
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Movie");
            }
            catch
            {
                return View("Create");
            }
        }
        #endregion
        #region "XOA VIDEO"
        public ActionResult Delete(int id)
        {
            return View(db.Films.Where(film => film.filmID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Film film)
        {
            film = db.Films.Where(m => m.filmID == id).FirstOrDefault();
            db.Films.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Movie");
        }
        #endregion

        #region "THONG TIN VIDEO"
        public ActionResult Details(int id)
        {
            return View(db.Films.Where(s => s.filmID == id).FirstOrDefault());
        }
        #endregion

        #region "SUA VIDEO"
        public ActionResult Edit(int id)
        {
            return View(db.Films.Where(f => f.filmID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Film film)
        {
            try
            {
                if (film.IMGupload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(film.IMGupload.FileName);
                    string extension = Path.GetExtension(film.IMGupload.FileName);
                    fileName = fileName + extension;
                    film.filmIMG = "~/Content/Img/" + fileName;
                    film.IMGupload.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), fileName));
                }
                db.Entry(film).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Movie");
            }
            catch 
            {
                return View("Edit");
            }
            
        }
        public ActionResult ChooseGen()
        {
            Film film = new Film();
            var genres = db.genres.Where(g => g.genreName != "nulll").ToList();
            ViewBag.Genres = new SelectList(genres, "genreID", "genreName");
            return PartialView(film);
        }
       
        #endregion

    }
}