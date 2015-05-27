using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongManager.DataAccess
{
    public class Context : DbContext, IContext
    {
        public DbSet<Song> Songs { get; set; }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(this);
        }
    }
}
