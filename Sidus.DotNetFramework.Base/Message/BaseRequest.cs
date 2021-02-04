using Microsoft.EntityFrameworkCore.Query;
using Sidus.DotNetFramework.Base.Entity;
using Sidus.DotNetFramework.Base.Entity.Interface;
using Sidus.DotNetFramework.Base.Message.Interface;
using Sidus.DotNetFramework.Base.Model;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sidus.DotNetFramework.Base.Message
{
    public class BaseRequest : IRequest
    {
        public BaseRequest()
        {
            this.Paging = new Paging();
        }

        public IPagingRequest Paging { get; set; }
        public IFilter Filter { get; set; }
    }

    public class BaseRequest<TModel> : BaseRequest, IRequest<TModel> where TModel : IModel // : BaseModel
    {
        public BaseRequest() : base() { }

        public TModel Model { get; set; }
        public IEnumerable<TModel> Models { get; set; }
    }

    public class BaseRequest<TEntity, TKey> : BaseRequest, IRequest<TEntity, TKey> where TEntity : IEntity<TKey> /* BaseEntity<TKey> */ where TKey : IEquatable<TKey>
    {
        public BaseRequest() : base() { }

        public TKey Key { get; set; }

        public IEnumerable<TKey> Keys { get; set; }

        public Expression<Func<TEntity, object>> Selector { get; set; }

        public new Expression<Func<TEntity, bool>> Filter { get; set; }

        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }

        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Include { get; set; }
    }

    public class BaseRequest<TEntity, TModel, TKey> : BaseRequest<TEntity, TKey>, IRequest<TEntity, TModel, TKey> where TEntity : IEntity<TKey> /* BaseEntity<TKey> */ where TModel : IModel<TKey> /*BaseModel<TKey>*/ where TKey : IEquatable<TKey>
    {
        public BaseRequest() : base() { }

        public new Expression<Func<TEntity, TModel>> Selector { get; set; }

        public TModel Model { get; set; }

        public IEnumerable<TModel> Models { get; set; }

        public virtual IEnumerable<TEntity> ToEntities() => throw new NotImplementedException();

        public virtual TEntity ToEntity() => throw new NotImplementedException();
    }
}
