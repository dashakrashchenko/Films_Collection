using System;
using System.Collections.Generic;

namespace DAL_Project.Models
{
    public partial class Films
    {
        public Films()
        {
            FavouriteFilms = new HashSet<FavouriteFilms>();
        }

        public int IdFilm { get; set; }
        public string Filmname { get; set; }
        public string Genre { get; set; }
        public DateTime? Releasedate { get; set; }
        public decimal? Budget { get; set; }
        public int? IdMaker { get; set; }
        public double? ImdbScore { get; set; }

        public virtual Filmmakers IdMakerNavigation { get; set; }
        public virtual ICollection<FavouriteFilms> FavouriteFilms { get; set; }
    }
}
