using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    class FilmmakersRepository: Repository<Filmmakers>, IFilmmakersRepository
    {
        public FilmmakersRepository(FilmsCollectionDBContext db)
        :base (db)
        { }
        
        public Filmmakers GetInfoAboutFilmmaker(string fullname)
        {
            string[] names = fullname.Split(' ');
            string fname = names[0];
            string sname = names[1];

            int id = FilmsCollectionDb.Filmmakers
                .Where(f => f.Lastname == sname && f.Firstname == fname)
                .Select(s => s.IdFilmmaker)
                .First();
            return FilmsCollectionDb.Filmmakers.Find(id);
        }

        public IEnumerable<Filmmakers> GetFilmmakerByGenre(string genre)
        {
            return FilmsCollectionDb.Filmmakers.Where(s => s.Genre == genre);
        }

        public IEnumerable<Filmmakers> GetFilmmakerbyAward(string award)
        {
            return FilmsCollectionDb.Filmmakers.Where(s => s.Awards == award);
        }


        public FilmsCollectionDBContext FilmsCollectionDb { get { return context as FilmsCollectionDBContext;} }
    }
}
