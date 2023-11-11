using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class GenreController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: ADMIN/Genre
        public ActionResult Genre()
        {
            return View(db.genres.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(genre genre)
        {
                var check = db.genres.Where(g=>g.genreName==genre.genreName).FirstOrDefault();
                if (check != null) 
                {
                    ViewBag.ErrorGen = "Thể loại đã tồn tại";
                    return View("Create");
                }
                db.genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Genre");
        }
        #region "XOA THE LOAI"
        public ActionResult Delete(int id)
        {
            return View(db.genres.Where(movie => movie.genreID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, genre genre)
        {
            try
            {
                genre = db.genres.Where(m => m.genreID == id).FirstOrDefault();
                var refer = db.Films.Where(f => f.filmGenre == id).ToList();
                foreach (var item in refer)
                {
                    item.filmGenre = 3;
                }
                db.genres.Remove(genre);
                db.SaveChanges();
                return RedirectToAction("Genre");
            }
            catch
            {
                return View("Delete");
            }
        }
        #endregion 
        #region "SUA THE LOAI"
        public ActionResult Edit(int id)
        {
            return View(db.genres.Where(m => m.genreID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, genre genre)
        {

            db.Entry(genre).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Genre");
        }
        #endregion  
    }
}