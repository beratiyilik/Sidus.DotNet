using Microsoft.EntityFrameworkCore;
using Sidus.DotNetFramework.Base.Entity;
using Sidus.DotNetFramework.Base.Message.Interface;
using Sidus.DotNetFramework.Base.Model;
using Sidus.DotNetFramework.Base.Repository.Interface;
using Sidus.DotNetFramework.Base.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sidus.DotNetFramework.Base.Message;
using static Sidus.DotNetFramework.Base.Enums.Enums;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Sidus.DotNetFramework.Base.Service
{
    public abstract class BaseService<TEntity, TModel, TKey> : IService<TEntity, TModel, TKey> where TEntity : BaseEntity<TKey> where TModel : BaseModel<TKey> where TKey : IEquatable<TKey>
    {
        private protected readonly IRepository<TEntity, TKey> _repository;

        public BaseService(IRepository<TEntity, TKey> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual IResponse<TEntity, TModel, TKey> Count(IRequest<TEntity, TModel, TKey> request) => this.CountAsync(request).GetAwaiter().GetResult();

        public virtual Task<IResponse<TEntity, TModel, TKey>> CountAsync(IRequest<TEntity, TModel, TKey> request)
        {
            var response = new BaseResponse<TEntity, TModel, TKey>();
            try
            {
                response.Count = this._repository.CountAsync(request.Filter).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<TEntity, TModel, TKey>>(response);
        }

        public virtual IResponse<TEntity, TModel, TKey> GetByPrimaryKey(TKey key) => this.GetByPrimaryKeyAsync(key).GetAwaiter().GetResult();

        public virtual Task<IResponse<TEntity, TModel, TKey>> GetByPrimaryKeyAsync(TKey key)
        {
            var response = new BaseResponse<TEntity, TModel, TKey>();
            try
            {
                var entity = this._repository.GetByPrimaryKeyAsync(key).GetAwaiter().GetResult();
                response.AddResult(this.ToModel(entity));
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<TEntity, TModel, TKey>>(response);
        }

        public virtual IResponse<TEntity, TModel, TKey> List(IRequest<TEntity, TModel, TKey> request) => this.ListAsync(request).GetAwaiter().GetResult();

        public virtual Task<IResponse<TEntity, TModel, TKey>> ListAsync(IRequest<TEntity, TModel, TKey> request)
        {
            var response = new BaseResponse<TEntity, TModel, TKey>();
            try
            {
                var result = this._repository.ListAsync(request.Filter, request.Include, request.OrderBy, request.Paging?.Skip, request.Paging?.Take).GetAwaiter().GetResult();
                response.AddResult(this.ToModels(result));
                response.AddMessage($"{result.Count()} item(s) listed successfully", OperationResult.Success);
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<TEntity, TModel, TKey>>(response);
        }

        public virtual IResponse<TEntity, TModel, TKey> Insert(IRequest<TEntity, TModel, TKey> request) => this.InsertAsync(request).GetAwaiter().GetResult();

        public virtual Task<IResponse<TEntity, TModel, TKey>> InsertAsync(IRequest<TEntity, TModel, TKey> request)
        {
            var response = new BaseResponse<TEntity, TModel, TKey>();
            try
            {
                var result = this._repository.InsertAsync(this.ToEntities(request.Models)).GetAwaiter().GetResult();
                response.AddResult(this.ToModels(result));
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<TEntity, TModel, TKey>>(response);
        }

        public virtual IResponse<TEntity, TModel, TKey> Update(IRequest<TEntity, TModel, TKey> request) => this.UpdateAsync(request).GetAwaiter().GetResult();

        public virtual Task<IResponse<TEntity, TModel, TKey>> UpdateAsync(IRequest<TEntity, TModel, TKey> request)
        {
            var response = new BaseResponse<TEntity, TModel, TKey>();
            try
            {
                var result = this._repository.UpdateAsync(this.ToEntities(request.Models)).GetAwaiter().GetResult();
                response.AddResult(this.ToModels(result));
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<TEntity, TModel, TKey>>(response);
        }

        public virtual IResponse<TEntity, TModel, TKey> Delete(IRequest<TEntity, TModel, TKey> request) => this.DeleteAsync(request).GetAwaiter().GetResult();

        public virtual Task<IResponse<TEntity, TModel, TKey>> DeleteAsync(IRequest<TEntity, TModel, TKey> request)
        {
            var response = new BaseResponse<TEntity, TModel, TKey>();
            try
            {
                this._repository.DeleteAsync(request.Key).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                response.AddError(ex);
            }
            return Task.FromResult<IResponse<TEntity, TModel, TKey>>(response);
        }

        public abstract TModel ToModel(TEntity entity);

        public abstract IEnumerable<TModel> ToModels(IEnumerable<TEntity> entities);

        public abstract TEntity ToEntity(TModel model);

        public abstract IEnumerable<TEntity> ToEntities(IEnumerable<TModel> models);

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
        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true) => this._repository.GetFirstOrDefault<TResult>(selector, filter, orderBy, include, disableTracking);

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
        public IEnumerable<TResult> GetAsEnumerable<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true) => this._repository.GetAsEnumerable<TResult>(selector, filter, orderBy, include, disableTracking);

        #endregion
    }
}
