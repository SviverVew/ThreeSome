using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Areas.ADMIN.Controllers
{
    public class VideoController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: ADMIN/Movie
        public ActionResult Video()
        {
            return View(db.espisodes.ToList());
        }

        #region "TAO MOI"
        [HttpGet]
        public ActionResult Create()
        {
            espisode video = new espisode();
            return View(video);
        }
        [HttpPost]
        public ActionResult Create(espisode video)
        {
            try
            {
                if (video.IMGupload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(video.IMGupload.FileName);
                    string extension = Path.GetExtension(video.IMGupload.FileName);
                    fileName = fileName + extension;
                    video.vidIMG = "~/Content/Img/" + fileName;
                    video.IMGupload.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), fileName));
                }
                db.espisodes.Add(video);
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
            return View(db.espisodes.Where(video => video.vidID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, espisode video)
        {
            video = db.espisodes.Where(m => m.vidID == id).FirstOrDefault();
            db.espisodes.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Video");
        }
        #endregion

        #region "THONG TIN VIDEO"
        public ActionResult Details(int id)
        {
            return View(db.espisodes.Where(s => s.vidID == id).FirstOrDefault());
        }
        #endregion

        #region "SUA VIDEO"
        public ActionResult Edit(int id)
        {
            return View(db.espisodes.Where(f => f.vidID == id).FirstOrDefault());
        }
        
        [HttpPost]
        public ActionResult Edit(int id, espisode video)
        {
            try
            {
                if (video.IMGupload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(video.IMGupload.FileName);
                    string extension = Path.GetExtension(video.IMGupload.FileName);
                    fileName = fileName + extension;
                    video.vidIMG = "~/Content/Img/" + fileName;
                    video.IMGupload.SaveAs(Path.Combine(Server.MapPath("~/Content/Img/"), fileName));
                }
                db.Entry(video).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Video");
            }
            catch
            {
                return View("Edit");
            }

        }
        public ActionResult ChooseFilm()
        {
            espisode espi = new espisode();
            var filmm = db.Films.ToList();
            ViewBag.FilmsList = new SelectList(filmm, "filmID", "filmTitle");
            return PartialView(espi);

        }
        #endregion
    }
}