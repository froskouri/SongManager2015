using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongManager.DataAccess
{
    public interface IContext
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
