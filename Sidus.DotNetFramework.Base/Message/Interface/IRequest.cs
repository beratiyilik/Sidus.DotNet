using Microsoft.EntityFrameworkCore.Query;
using Sidus.DotNetFramework.Base.Entity.Interface;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sidus.DotNetFramework.Base.Message.Interface
{
    public interface IRequest
    {
        IPagingRequest Paging { get; set; }

        IFilter Filter { get; set; }
    }

    public interface IRequest<TModel> : IRequest where TModel : IModel
    {
        TModel Model { get; set; }
        IEnumerable<TModel> Models { get; set; }
    }

    public interface IRequest<TEntity, TKey> : IRequest where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        TKey Key { get; set; }
        IEnumerable<TKey> Keys { get; set; }
        Expression<Func<TEntity, object>> Selector { get; set; }
        new Expression<Func<TEntity, bool>> Filter { get; set; }
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Include { get; set; }
    }

    public interface IRequest<TEntity, TModel, TKey> : IRequest<TEntity, TKey>, IRequest<TModel>, IRequest where TEntity : IEntity<TKey> where TModel : IModel<TKey> where TKey : IEquatable<TKey>
    {
        new Expression<Func<TEntity, TModel>> Selector { get; set; }
        TEntity ToEntity();
        IEnumerable<TEntity> ToEntities();
    }
}
