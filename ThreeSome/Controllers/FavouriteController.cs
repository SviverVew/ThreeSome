using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class FavouriteController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: Favourite
        public ActionResult Index()
        {
            return View(db.Films.ToString());
        }
    }
}