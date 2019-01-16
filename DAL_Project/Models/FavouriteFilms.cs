using System;
using System.Collections.Generic;

namespace DAL_Project.Models
{
    public partial class FavouriteFilms
    {
        public int? FilmId { get; set; }
        public int FavoriteFilmId { get; set; }

        public virtual Films Film { get; set; }
    }
}
