using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ThreeSome.Models
{
    public class FavItem
    {
        public Film _film { get; set; }
    }
    public class ListFavourite
    {
        List<FavItem> fav_item = new List<FavItem>();

        public IEnumerable<FavItem> FAV_ITEM
        {
            get { return fav_item; }
        }
        public void AddNew(Film film)
        {
            var item = fav_item.FirstOrDefault(s => s._film.filmID == film.filmID);
            if (item == null)
            {
                fav_item.Add(new FavItem
                {
                    _film = film
                });
            }
            else
            {
                item._film = film;
            }
        }
        public void delete_fromlist(Film film)
        {
            var item = fav_item.FirstOrDefault(s => s._film.filmID == film.filmID);
            if (item != null)
            {
                fav_item.Remove(item);
            }
        }
    }
}