using System;
using System.Collections.Generic;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    public interface IFilmmakersRepository: IRepository<Filmmakers>
    {
        Filmmakers GetInfoAboutFilmmaker(string fullname);
        IEnumerable<Filmmakers> GetFilmmakerByGenre(string genre);
        IEnumerable<Filmmakers> GetFilmmakerbyAward(string award);
    }
}
