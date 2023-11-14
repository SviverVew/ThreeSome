using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class SearchController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: Search
        [HttpPost]
        public ActionResult SearchResult(string tukhoa, ActionResult action)
        {
           
                ViewBag.Search = tukhoa;
                var list = db.Films.Where(film => film.filmTitle.Contains(tukhoa));
                return View(list.OrderBy(film => film.filmTitle));
            
        }
    }
}
