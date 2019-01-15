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
            try
            {
                int idfilm = FilmsCollectionDb.Films.Where(f => f.Filmname == filmname)
                .Select(f => f.IdFilm).First();
                
                FavouriteFilms favfilms = new FavouriteFilms();
                favfilms.IdF = idfilm;
                
                FilmsCollectionDb.FavouriteFilms.Add(favfilms);
            }
            catch(Exception)
            {            
                throw new Exception("Film not found");
            }
          
            
        }

        public void RemoveFromFavFilms(string filmname)
        {
            try
            {
                int idfilm = FilmsCollectionDb.Films.Where(f => f.Filmname == filmname)
                .Select(f => f.IdFilm).First();

                var filmv = FilmsCollectionDb.FavouriteFilms.Where(f => f.IdF == idfilm);

                FilmsCollectionDb.FavouriteFilms.Remove(filmv.First());
            }
            catch(Exception)
            {
                throw new Exception("Film not found");
            }
            
        }





        private FilmsCollectionDBContext FilmsCollectionDb
        {
            get { return context as FilmsCollectionDBContext; }
        }
    }
}
