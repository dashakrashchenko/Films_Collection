using System;
using System.Collections.Generic;

namespace DAL_Project.Models
{
    public partial class Films
    {
        public int FilmId { get; set; }
        public string Filmname { get; set; }
        public string Genre { get; set; }
        public DateTime? Releasedate { get; set; }
        public decimal? Budget { get; set; }
        public int? MakerId { get; set; }
        public double? ImdbScore { get; set; }

        public virtual Filmmakers Maker { get; set; }
        public virtual FavouriteFilms FavouriteFilms { get; set; }
    }
}
