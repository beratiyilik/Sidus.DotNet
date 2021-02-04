using Sidus.DotNetFramework.Base.Entity.Interface;
using Sidus.DotNetFramework.Base.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sidus.DotNetFramework.Base.Enums.Enums;

namespace Sidus.DotNetFramework.Base.Message.Interface
{
    public interface IResponse
    {
        IEnumerable<IResponseMessage> Messages { get; }
        bool HasError { get; }
        void AddMessage(string message, OperationResult type);
        void AddWarning(string message);
        void AddWarning(string message, params object[] args);
        void AddError(string error);
        void AddError(IEnumerable<string> errors);
        void AddError(Exception ex);
    }

    public interface IResponse<TModel> : IResponse where TModel : IModel
    {
        IEnumerable<TModel> Results { get; }
        TModel Result { get; }
        bool AnyResult { get; }
        public int Count { get; set; }
        void AddResult(TModel model);
        void AddResult(IEnumerable<TModel> models);
        IPagingResponse Paging { get; set; }
    }

    public interface IResponse<TEntity, TKey> : IResponse where TEntity : IEntity<TKey> where TKey : IEquatable<TKey>
    {

    }

    public interface IResponse<TEntity, TModel, TKey> : IResponse<TEntity, TKey>, IResponse<TModel>, IResponse where TEntity : IEntity<TKey> where TModel : IModel<TKey> where TKey : IEquatable<TKey>
    {
        void AddResult(TEntity entity);
        void AddResult(IEnumerable<TEntity> entities);
    }
}
