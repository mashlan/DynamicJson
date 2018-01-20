using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : IAssetTrackEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Single(Expression<Func<TEntity, bool>> expression);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}

