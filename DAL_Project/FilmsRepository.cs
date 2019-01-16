using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    class FilmsRepository:Repository<Films>, IFilmsRepository
    {
        public FilmsRepository(FilmsCollectionDBContext cont)
            :base(cont)
        { }

        public IEnumerable<Films> GetAllFilmsByFilmmaker(string firstname, string lastname)
        {        

            int id = FilmsCollectionDb.Filmmakers
                .Where(f => f.Lastname == lastname && f.Firstname == firstname)
                .Select(s => s.FilmMakerId)
                .First();

            //var result = from film in FilmsCollectionDb.Films
            //    where film.MakerId == id
            //    select film;
            var result = FilmsCollectionDb.Films.Where(f => f.MakerId == id);

            return result;
        }

        public Films GetInfoAboutFilm(string filmname)
        {

            return FilmsCollectionDb.Films.Where(s => s.Filmname == filmname).First();
        }

        public IEnumerable<Films> GetAllFilmsByGenre(string genre)
        {
            return FilmsCollectionDb.Films.Where(s => s.Genre == genre);
        }

        public IEnumerable<Films> GetSortedByImdb()
        {
            return FilmsCollectionDb.Films.OrderByDescending(s => s.ImdbScore);
        }

        public IEnumerable<Films> GetAllFilmsByReleaseDate(DateTime date)
        {
            return FilmsCollectionDb.Films.Where(s => s.Releasedate.Value.Date == date);
        }
        public FilmsCollectionDBContext FilmsCollectionDb
        {
            get { return context as FilmsCollectionDBContext; }
        }
    }
}
