using Sidus.DotNetFramework.Base.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Sidus.DotNetFramework.Base.Repository.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        IQueryable<TEntity> Query();
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> filter);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);
        bool IsExist(TKey key);
        Task<bool> IsExistsAsync(TKey key);
        bool IsExist(Expression<Func<TEntity, bool>> filter);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter);
        TEntity GetByPrimaryKey(TKey key);
        Task<TEntity> GetByPrimaryKeyAsync(TKey key);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        IEnumerable<TEntity> List();
        Task<IEnumerable<TEntity>> ListAsync();
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter);
        // IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, int? skip = null, int? take = null);
        // Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, int? skip = null, int? take = null);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
        // IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, int? skip = null, int? take = null);
        // Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, int? skip = null, int? take = null);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip = null, int? take = null);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        void Delete(TKey key);
        Task DeleteAsync(TKey key);
        void Delete(IEnumerable<TKey> keys);
        Task DeleteAsync(IEnumerable<TKey> keys);

        #region Experimental

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="include"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        IEnumerable<TResult> GetAsEnumerable<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);

        #endregion
    }

    public interface IRepository<TEntity, TKey, TContext> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : IEquatable<TKey> where TContext : DbContext
    {

    }
}
