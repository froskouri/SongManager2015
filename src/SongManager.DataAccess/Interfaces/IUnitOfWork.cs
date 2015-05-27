using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongManager.DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
        void CommitChanges();

        GenericRepository<T> GetRepository<T>() where T : class;
    }
}
