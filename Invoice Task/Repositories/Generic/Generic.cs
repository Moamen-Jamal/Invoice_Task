using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    public class Generic<T> where T : BaseModel
    {
        DbSet<T> dbSet;
        public EntitiesContext Context { get; set; }
        public Generic(EntitiesContext context)
        {
            Context = context;
            dbSet = Context.Set<T>();
        }
        public IQueryable<T> GetList()
        {
            return dbSet;
        }
        public IQueryable<T> Get(Expression<Func<T,bool>> predicate)
        {

            return dbSet.Where(predicate);
        }
        public T GetByID(int id)
        {
            return dbSet.FirstOrDefault(i => i.ID == id);
        }
        public EntityEntry<T> Add(T T)
        {
            return dbSet.Add(T);

        }
        public T Update(T T)
        {
            if (!dbSet.Local.Any(i => i.ID == T.ID))
                dbSet.Attach(T);
            Context.Entry(T).State = EntityState.Modified;
            return T;
        }
        public void Remove(T T)
        {
            dbSet.Remove(T);
        }
    }
}
