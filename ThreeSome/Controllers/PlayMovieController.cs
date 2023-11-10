using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;

namespace ThreeSome.Controllers
{
    public class PlayMovieController : Controller
    {
        WEBEntitiesEntities db = new WEBEntitiesEntities();
        // GET: PlayMovie
        public ActionResult Video()
        {
            return View(db.espisodes.ToList());
        }
    }
}