using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeSome.Models
{
    public class FilmModel
    {
        public string VidAddress {  get; set; }
        public string VidTitle { get; set; }
        public string VidIMG { get; set; }
        public int FilmID {  get; set; }
        public string FilmTitle { get; set; }
        public string FilmImg { get; set;}
        public string FilmDes { get; set; }
        public string FilmLink {  get; set; }
        public List<TapPhimModel> TapPhims { get; set; }
    }
}