using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL_Project
{
    class Repository<T> : IRepository<T> where T:class
    {
        protected DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> pred)
        {
            return context.Set<T>().Where(pred);
        }

        public void Add(T t)
        {
            context.Set<T>().Add(t);
        }

        public void Remove(T t)
        {
            context.Set<T>().Remove(t);
        }
    }
}
