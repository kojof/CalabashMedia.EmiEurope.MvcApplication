using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.DataAccess.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();
        void Delete(TEntity entity);
        TEntity Add(TEntity entity);
    }
}
