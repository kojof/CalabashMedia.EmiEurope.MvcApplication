using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CalabashMedia.EmiEurope.DataAccess.Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        Int32 SaveChanges();
        void Dispose();
    }
}
