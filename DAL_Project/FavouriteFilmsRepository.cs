using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    class FavouriteFilmsRepository:Repository<FavouriteFilms>,IFavouriteFilmsRepository
    {
        public FavouriteFilmsRepository(FilmsCollectionDBContext cont)
           :base(cont)
        { }

        public void AddToFavFilms(string filmname)
        {
            int idfilm = FilmsCollectionDb.Films.Where(f => f.Filmname == filmname)
                .Select(f => f.IdFilm).First();

            int? idmaker = FilmsCollectionDb.Films.Where(f => f.Filmname == filmname)
                .Select(f => f.IdMaker).First();

            FavouriteFilms temp = new FavouriteFilms();
            temp.IdF = idfilm;
            temp.IdM = idmaker;
            FilmsCollectionDb.FavouriteFilms.Add(temp);
        }

        public void RemoveFromFavFilms(string filmname)
        {

            int idfilm = FilmsCollectionDb.Films.Where(f => f.Filmname == filmname)
                .Select(f => f.IdFilm).First();

            var film = from f in FilmsCollectionDb.FavouriteFilms
                where f.IdF == idfilm
                select f;

            FilmsCollectionDb.FavouriteFilms.Remove(film.First());
        }





        private FilmsCollectionDBContext FilmsCollectionDb
        {
            get { return context as FilmsCollectionDBContext; }
        }
    }
}
