using System;
using System.Collections.Generic;

namespace DAL_Project.Models
{
    public partial class FavouriteFilms
    {
        public int? IdF { get; set; }
        public int? IdM { get; set; }
        public int FavId { get; set; }

        public virtual Films IdFNavigation { get; set; }
        public virtual Filmmakers IdMNavigation { get; set; }
    }
}
