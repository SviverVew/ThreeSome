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
        public ActionResult Favourite()
        {
            if (Session["ListFavourite"] == null)
            {
                return View("Favourite");
            }
            ListFavourite listFav = Session["ListFavourite"] as ListFavourite;
            return View(listFav);
        }

        public ListFavourite GetList()
        {
            ListFavourite list_fav = Session["ListFavourite"] as ListFavourite;
            if (list_fav == null || Session["ListFavourite"] == null)
            {
                list_fav = new ListFavourite();
                Session["ListFavourite"] = list_fav;
            }
            return list_fav;
        }

        //Them vao ds yeu thich
        public ActionResult AddtoFav(int id)
        {
            var film = db.Films.SingleOrDefault(f => f.filmID == id);
            if (film != null || Session["Name"] != null)
            {
                GetList().AddNew(film);
            }
            if (Session["Name"] != null) { 
            string filmId = film.filmID.ToString();
            string url = Url.Action("FilmDetail", "FilmTag");
            url +="?FilmId=" + filmId;
            return Redirect(url);
            }
            else
            {
               return RedirectToAction("Login", "Login");
            }
        }

        //Xoa khoi ds yeu thich
        public ActionResult RemoveFromList(int id)
        {
            var film = db.Films.SingleOrDefault(f => f.filmID == id);
            if (film != null)
            {
                GetList().delete_fromlist(film);
            }
            return RedirectToAction("Favourite", "Favourite");
        }
    }
}

