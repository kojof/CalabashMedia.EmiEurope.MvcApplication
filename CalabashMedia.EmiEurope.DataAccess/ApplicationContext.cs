using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using CalabashMedia.EmiEurope.DataAccess.Interfaces;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.DataAccess
{
    public class ApplicationContext: DbContext, IDbContext
    {
        public DbSet<Vacancy> Vacancy { get; set; }
        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
