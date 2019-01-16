using System;
using System.Collections.Generic;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    interface IFavouriteFilmRepository:IRepository<FavouriteFilm>
    {
        void AddToFavFilms(string filmname);
        void RemoveFromFavFilms(string filmname);
    }
}
