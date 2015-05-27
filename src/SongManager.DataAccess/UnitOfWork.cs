using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongManager.DataAccess
{
    public class UnitOfWork: IUnitOfWork
    {
        private Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public GenericRepository<T> GetRepository<T>() where T:class
        {
            return new GenericRepository<T>(_context);
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            
        }
    }
}
