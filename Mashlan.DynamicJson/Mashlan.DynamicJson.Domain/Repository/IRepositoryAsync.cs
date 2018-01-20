using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.Domain.Repository
{
    public interface IRepositoryAsync<TEntity> where TEntity : IAssetTrackEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}