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
                var newfilm = FilmsCollectionDb.Films.Where(t => t.Filmname == filmname).FirstOrDefault();
                FavouriteFilms favfilms = new FavouriteFilms();
                favfilms.Film = newfilm;

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
                var olditem = FilmsCollectionDb.Films.Where(t => t.Filmname == filmname).FirstOrDefault();
                var a = FilmsCollectionDb.FavouriteFilms.Where(t => t.Film == olditem).FirstOrDefault();
                FilmsCollectionDb.FavouriteFilms.Remove(a);
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
