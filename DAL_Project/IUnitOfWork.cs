using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Project
{
    public interface IUnitOfWork: IDisposable 
    {
        IFilmmakersRepository Filmmakers { get; }
        int Complete();
    }
}
