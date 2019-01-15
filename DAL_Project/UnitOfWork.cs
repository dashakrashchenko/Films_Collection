using System;
using System.Collections.Generic;
using System.Text;
using DAL_Project.Models;

namespace DAL_Project
{
    class UnitOfWork:IUnitOfWork
    {
        private readonly FilmsCollectionDBContext _context;

        public UnitOfWork(FilmsCollectionDBContext context)
        {
            _context = context;
            Filmmakers = new FilmmakersRepository(_context);
            Films = new FilmsRepository(_context);
            FavouriteFilms = new FavouriteFilmsRepository(_context);
        }
        public IFilmmakersRepository Filmmakers { get; private set; }
        public IFilmsRepository Films { get; private set; }
        public  IFavouriteFilmsRepository FavouriteFilms { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
