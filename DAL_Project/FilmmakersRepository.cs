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
            fullname = fullname.Replace(" ", string.Empty);          

            int id = FilmsCollectionDb.Filmmakers
               .Where(f=>(f.Firstname+f.Lastname).Replace(" ", string.Empty)==fullname)
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
