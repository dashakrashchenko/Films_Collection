using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_Project.Models;
using Microsoft.EntityFrameworkCore;


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
                var newfilm = FilmsCollectionDb.Films.Where(t => t.Filmname == filmname).Include(t => t.FavouriteFilms).FirstOrDefault();

                FavouriteFilms favfilms = new FavouriteFilms();
                favfilms.IdF = newfilm.IdFilm;

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
                var oldfilm = FilmsCollectionDb.Films.Where(t => t.Filmname == filmname).Include(t => t.FavouriteFilms).FirstOrDefault();
                FilmsCollectionDb.FavouriteFilms.Remove(FilmsCollectionDb.FavouriteFilms.Where(f=>f.IdF==oldfilm.IdFilm).FirstOrDefault());
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
