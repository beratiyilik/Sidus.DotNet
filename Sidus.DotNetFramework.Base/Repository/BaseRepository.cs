using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNetFramework.Base.Repository.Interface;
using Sidus.DotNetFramework.Base.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Sidus.DotNetFramework.Base.Entity.Interface;

namespace Sidus.DotNetFramework.Base.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _db;

        public BaseRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this._db = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Query() => (from m in this._db select m);

        public virtual int Count() => this.CountAsync().GetAwaiter().GetResult();

        public virtual Task<int> CountAsync() => this.CountAsync(null);

        public virtual int Count(Expression<Func<TEntity, bool>> filter) => this.CountAsync(filter).GetAwaiter().GetResult();

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = Query();

            query = filter != null ? query.Where(filter) : query;

            return query.CountAsync();
        }

        public virtual bool IsExist(TKey key) => this.IsExistsAsync(key).GetAwaiter().GetResult();

        public virtual Task<bool> IsExistsAsync(TKey key) => this.IsExistsAsync(m => m.Id.Equals(key));

        public virtual bool IsExist(Expression<Func<TEntity, bool>> filter) => this.IsExistsAsync(filter).GetAwaiter().GetResult();

        public virtual Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter) => Query().AnyAsync(filter);

        public virtual TEntity GetByPrimaryKey(TKey key) => this.GetByPrimaryKeyAsync(key).GetAwaiter().GetResult();

        public virtual Task<TEntity> GetByPrimaryKeyAsync(TKey key) => Query().FirstOrDefaultAsync(m => m.Id.Equals(key));

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter) => this.FirstOrDefaultAsync(filter).GetAwaiter().GetResult();

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter) => this.FirstOrDefaultAsync(filter, null);

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include) => this.FirstOrDefaultAsync(filter, include).GetAwaiter().GetResult();

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            IQueryable<TEntity> query = Query();

            query = filter != null ? query.Where(filter) : query;

            query = include != null ? include(query) : query;

            return query.FirstOrDefaultAsync();
        }

        public virtual IEnumerable<TEntity> List() => this.ListAsync().GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> ListAsync() => this.ListAsync(null);

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter) => this.ListAsync(filter).GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter) => this.ListAsync(filter, null);

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include) => this.ListAsync(filter, include).GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include) => this.ListAsync(filter, include, null);

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) => this.ListAsync(filter, include, orderBy).GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy) => this.ListAsync(filter, include, orderBy, null, null);

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip = null, int? take = null) => this.ListAsync(filter, include, orderBy, skip, take).GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int? skip = null, int? take = null)
        {
            IQueryable<TEntity> query = Query();

            query = filter != null ? query.Where(filter) : query;

            query = include != null ? include(query) : query;

            query = orderBy != null ? orderBy(query).AsQueryable() : query;

            query = skip.GetValueOrDefault() != 0 ? query.Skip(skip.GetValueOrDefault()) : query;

            query = take.GetValueOrDefault() != 0 ? query.Take(take.GetValueOrDefault()) : query;

            return Task.FromResult<IEnumerable<TEntity>>(query.AsEnumerable());
        }

        public virtual int SaveChanges() => this.SaveChangesAsync().GetAwaiter().GetResult();

        public virtual Task<int> SaveChangesAsync() => this._context.SaveChangesAsync();

        public virtual TEntity Insert(TEntity entity) => this.InsertAsync(entity).GetAwaiter().GetResult();

        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            _db.Add(entity);

            var result = this.SaveChangesAsync().GetAwaiter().GetResult();

            if (result > 0)
            {
                return Task.FromResult<TEntity>(entity);
            }

            return Task.FromResult<TEntity>(null);
        }

        public virtual IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities) => this.InsertAsync(entities).GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities)
        {
            _db.AddRange(entities);

            var result = this.SaveChangesAsync().GetAwaiter().GetResult();

            if (result > 0)
            {
                return Task.FromResult<IEnumerable<TEntity>>(entities);
            }

            return Task.FromResult<IEnumerable<TEntity>>(null);
        }

        public virtual TEntity Update(TEntity entity) => this.UpdateAsync(entity).GetAwaiter().GetResult();

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.LastModifiedAt = DateTime.UtcNow;
            // entity.LastModifiedById = 

            var result = this.SaveChangesAsync().GetAwaiter().GetResult();

            if (result > 0)
            {
                return Task.FromResult<TEntity>(entity);
            }

            return Task.FromResult<TEntity>(null);
        }

        public virtual IEnumerable<TEntity> Update(IEnumerable<TEntity> entities) => this.UpdateAsync(entities).GetAwaiter().GetResult();

        public virtual Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.LastModifiedAt = DateTime.UtcNow;
                // entity.LastModifiedById = 
            }

            var result = this.SaveChangesAsync().GetAwaiter().GetResult();

            if (result > 0)
            {
                return Task.FromResult<IEnumerable<TEntity>>(entities);
            }

            return Task.FromResult<IEnumerable<TEntity>>(null);
        }

        public virtual void Delete(TKey key) => this.DeleteAsync(key).GetAwaiter().GetResult();

        public virtual Task DeleteAsync(TKey key)
        {
            var entity = this.GetByPrimaryKeyAsync(key).GetAwaiter().GetResult();

            entity.State = Enums.Enums.EntityState.Deleted;

            return this.UpdateAsync(entity);
        }

        public virtual void Delete(IEnumerable<TKey> keys) => this.DeleteAsync(keys).GetAwaiter().GetResult();

        public virtual Task DeleteAsync(IEnumerable<TKey> keys)
        {
            var entityList = this.ListAsync(m => keys.Contains(m.Id)).GetAwaiter().GetResult();

            foreach (var entity in entityList)
            {
                entity.State = Enums.Enums.EntityState.Deleted;
            }

            return this.UpdateAsync(entityList);
        }

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
        public virtual TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = Query();

            query = disableTracking ? query.AsNoTracking() : query;

            query = filter != null ? query.Where(filter) : query;

            query = include != null ? include(query) : query;

            query = orderBy != null ? orderBy(query).AsQueryable() : query;

            return query.Select(selector).FirstOrDefault();
        }

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
        public IEnumerable<TResult> GetAsEnumerable<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = Query();

            query = disableTracking ? query.AsNoTracking() : query;

            query = filter != null ? query.Where(filter) : query;

            query = include != null ? include(query) : query;

            query = orderBy != null ? orderBy(query).AsQueryable() : query;

            return query.Select(selector).AsEnumerable();
        }

        #endregion
    }

    public abstract class BaseRepository<TEntity, TKey, TContext> : BaseRepository<TEntity, TKey>, IRepository<TEntity, TKey, TContext> where TEntity : BaseEntity<TKey> /* IEntity<TKey> */ where TKey : IEquatable<TKey> where TContext : DbContext
    {
        public BaseRepository(TContext context) : base(context)
        {

        }
    }
}
