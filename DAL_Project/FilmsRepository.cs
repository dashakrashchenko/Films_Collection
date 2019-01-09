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

        public IEnumerable<Films> GetAllFilmsByFilmmaker(string fullname)
        {
            string[] names = fullname.Split(' ');
            string fname = names[0];
            string sname = names[1];

            int id = FilmsCollectionDb.Filmmakers
                .Where(f => f.Lastname == sname && f.Firstname == fname)
                .Select(s => s.IdFilmmaker)
                .First();

            var result = from film in FilmsCollectionDb.Films
                where film.IdMaker == id
                select film;

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

        public IEnumerable<Films> GetBestFilmsByImdb()
        {
            return FilmsCollectionDb.Films.OrderBy(s => s.ImdbScore);
        }

        public IEnumerable<Films> GetAllFilmsByReleaseDate()
        {
            string pattern = "MM-dd-yyyy";
            Console.WriteLine($"Date input pattern: {pattern}");
            Console.WriteLine();
            string release = Console.ReadLine();
            DateTime parsedDate;
            DateTime.TryParseExact(release, pattern, null, DateTimeStyles.None, out parsedDate);
            return FilmsCollectionDb.Films.Where(s => s.Releasedate == parsedDate);
        }
        public FilmsCollectionDBContext FilmsCollectionDb
        {
            get { return context as FilmsCollectionDBContext; }
        }
    }
}
