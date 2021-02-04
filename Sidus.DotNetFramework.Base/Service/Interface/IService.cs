using Microsoft.EntityFrameworkCore.Query;
using Sidus.DotNetFramework.Base.Entity.Interface;
using Sidus.DotNetFramework.Base.Message.Interface;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Service.Interface
{
    public interface IService<TEntity, TModel, TKey> where TEntity : IEntity<TKey> where TModel : IModel<TKey> where TKey : IEquatable<TKey>
    {
        IResponse<TEntity, TModel, TKey> Count(IRequest<TEntity, TModel, TKey> request);
        Task<IResponse<TEntity, TModel, TKey>> CountAsync(IRequest<TEntity, TModel, TKey> request);
        IResponse<TEntity, TModel, TKey> GetByPrimaryKey(TKey key);
        Task<IResponse<TEntity, TModel, TKey>> GetByPrimaryKeyAsync(TKey key);
        IResponse<TEntity, TModel, TKey> List(IRequest<TEntity, TModel, TKey> request);
        Task<IResponse<TEntity, TModel, TKey>> ListAsync(IRequest<TEntity, TModel, TKey> request);
        IResponse<TEntity, TModel, TKey> Insert(IRequest<TEntity, TModel, TKey> request);
        Task<IResponse<TEntity, TModel, TKey>> InsertAsync(IRequest<TEntity, TModel, TKey> request);
        IResponse<TEntity, TModel, TKey> Update(IRequest<TEntity, TModel, TKey> request);
        Task<IResponse<TEntity, TModel, TKey>> UpdateAsync(IRequest<TEntity, TModel, TKey> request);
        IResponse<TEntity, TModel, TKey> Delete(IRequest<TEntity, TModel, TKey> request);
        Task<IResponse<TEntity, TModel, TKey>> DeleteAsync(IRequest<TEntity, TModel, TKey> request);
        TModel ToModel(TEntity entity);
        IEnumerable<TModel> ToModels(IEnumerable<TEntity> entities);
        TEntity ToEntity(TModel model);
        IEnumerable<TEntity> ToEntities(IEnumerable<TModel> models);

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
}
