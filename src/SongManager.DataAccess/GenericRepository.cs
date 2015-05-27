using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongManager.DataAccess
{
    public class GenericRepository<T> where T: class
    {
        private DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _dbSet = context.Set<T>();
        }

        public void Insert(T toInsert)
        {
            _dbSet.Add(toInsert);
        }

        public void Delete(T toDelete)
        {
            _dbSet.Remove(toDelete);
        }

        public void Edit(T toEdit)
        {
            _dbSet.Update(toEdit);
        }

        public IQueryable<T> Get()
        {
            return _dbSet.AsQueryable();
        }
    }
}
