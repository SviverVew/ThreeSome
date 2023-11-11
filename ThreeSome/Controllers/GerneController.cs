using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeSome.Models;
namespace ThreeSome.Controllers
{
    public class GerneController : Controller
    {
        WEBEntitiesEntities db=new WEBEntitiesEntities();
        // GET: Gerne
        public ActionResult Index()
        {
            return PartialView(db.genres.ToList());
        }
    }
}