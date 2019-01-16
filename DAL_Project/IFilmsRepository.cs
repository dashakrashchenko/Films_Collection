using System;
using System.Collections.Generic;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    interface IFilmsRepository: IRepository<Films>
    {
        IEnumerable<Films> GetAllFilmsByFilmmaker(string fullname);
        Films GetInfoAboutFilm(string filmname);
        IEnumerable<Films> GetAllFilmsByGenre(string genre);
        IEnumerable<Films> GetAllFilmsByReleaseDate(DateTime date);
        IEnumerable<Films> GetSortedByImdb();
    }
}
